﻿// Author: Josef Pelikan

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using MathSupport;
using OpenglSupport;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Utilities;

namespace _087fireworks
{
  /// <summary>
  /// Rocket/particle launcher.
  /// Primary purpose: generate rockets/particles.
  /// If rendered, usually by triangles.
  /// </summary>
  public class Launcher : DefaultRenderObject
  {
    /// <summary>
    /// Particle source position.
    /// </summary>
    public Vector3 position;

    /// <summary>
    /// Particle source aim (initial direction of the particles).
    /// </summary>
    public Vector3 aim;

    /// <summary>
    /// Particle source up vector (initial up vector of the particles).
    /// </summary>
    public Vector3 up;

    /// <summary>
    /// Number of particles generated in every second.
    /// </summary>
    public float frequency;

    /// <summary>
    /// Last simulated time in seconds.
    /// </summary>
    public float simTime;

    /// <summary>
    /// Global constant launcher color.
    /// </summary>
    static Vector3 color = new Vector3( 1.0f, 0.4f, 0.2f );

    /// <summary>
    /// Shared random generator. Should be Locked if used in multi-thread environment.
    /// </summary>
    static RandomJames rnd = new RandomJames();

    /// <summary>
    /// Simulate object to the given time.
    /// </summary>
    /// <param name="time">Required target time.</param>
    /// <param name="fw">Simulation context.</param>
    /// <returns>False in case of expiry.</returns>
    public bool Simulate ( float time, Fireworks fw )
    {
      if ( time <= simTime )
        return true;

      float dt = time - simTime;
      // generate new particles for the [simTime-time] interval:

      float probability = dt * frequency;
      while ( probability > 1.0f ||
              rnd.UniformNumber() < probability )
      {
        // emit a new particle:
        Vector3d dird = Geometry.RandomDirectionNormal( rnd, new Vector3d( aim.X, aim.Y, aim.Z ), 0.02 ); // random direction around 'aim'
        Vector3 dir = new Vector3( (float)dird.X, (float)dird.Y, (float)dird.Z );                        // we need float-version of the vector
        Particle p = new Particle( position, dir * rnd.RandomFloat( 0.2f, 0.8f ), up,
                                   new Vector3( rnd.RandomFloat( 0.1f, 1.0f ), rnd.RandomFloat( 0.1f, 1.0f ), rnd.RandomFloat( 0.1f, 1.0f ) ),
                                   rnd.RandomFloat( 0.5f, 3.0f ), time, rnd.RandomFloat( 2.0f, 12.0f ) );
        fw.AddParticle( p );
        probability -= 1.0f;
      }

      simTime = time;

      return true;
    }

    public Launcher ( float freq )
    {
      position = Vector3.Zero;
      aim = new Vector3( 0.1f, 1.0f, -0.05f );
      aim.Normalize();
      up = new Vector3( 0.0f, 0.05f, 1.0f );
      up.Normalize();
      frequency = freq;      // number of emitted particles per second
      simTime = 0.0f;
    }

    // --- rendering ---

    public override uint Triangles
    {
      get
      {
        return 1;
      }
    }

    static Vector2 txt10 = new Vector2( 1.0f, 0.0f );
    static Vector2 txt01 = new Vector2( 0.0f, 1.0f );

    public override unsafe int TriangleVertices ( ref float* ptr, ref uint origin, out int stride, bool txt, bool col, bool normal, bool ptsize )
    {
      int total = base.TriangleVertices( ref ptr, ref origin, out stride, txt, col, normal, ptsize );
      if ( ptr == null )
        return total;

      Vector3 n = Vector3.Cross( aim, up ).Normalized();

      // 1. center
      if ( txt )
        Fill( ref ptr, Vector2.Zero );
      if ( col )
        Fill( ref ptr, ref color );
      if ( normal )
        Fill( ref ptr, ref n );
      if ( ptsize )
        *ptr++ = 1.0f;
      Fill( ref ptr, ref position );

      // 2. aim
      if ( txt )
        Fill( ref ptr, ref txt10 );
      if ( col )
        Fill( ref ptr, ref color );
      if ( normal )
        Fill( ref ptr, ref n );
      if ( ptsize )
        *ptr++ = 1.0f;
      Fill( ref ptr, position + 0.2f * aim );

      // 3. up
      if ( txt )
        Fill( ref ptr, ref txt01 );
      if ( col )
        Fill( ref ptr, ref color );
      if ( normal )
        Fill( ref ptr, ref n );
      if ( ptsize )
        *ptr++ = 1.0f;
      Fill( ref ptr, position + 0.1f * up );

      return total;
    }

    public override unsafe int TriangleIndices ( ref uint* ptr, uint origin )
    {
      if ( ptr != null )
      {
        *ptr++ = origin++;
        *ptr++ = origin++;
        *ptr++ = origin;
      }

      return 3 * sizeof( uint );
    }
  }

  /// <summary>
  /// Fireworks particle - active (rocket) or passive (glowing particle) element
  /// of the simulation. Rendered usually by a GL_POINT primitive.
  /// </summary>
  public class Particle : DefaultRenderObject
  {
    /// <summary>
    /// Current particle position.
    /// </summary>
    public Vector3 position;

    /// <summary>
    /// Current particle velocity.
    /// </summary>
    public Vector3 velocity;

    /// <summary>
    /// Current particle up vector.
    /// </summary>
    public Vector3 up;

    /// <summary>
    /// Particle color.
    /// </summary>
    public Vector3 color;

    /// <summary>
    /// Particle size in pixels.
    /// </summary>
    public float size;

    /// <summary>
    /// Time of death.
    /// </summary>
    public float maxAge;

    /// <summary>
    /// Last simulated time in seconds.
    /// </summary>
    public float simTime;

    public Particle ( Vector3 pos, Vector3 vel, Vector3 _up, Vector3 col, float siz, float time, float age )
    {
      position = pos;
      velocity = vel;
      up = _up;
      color = col;
      size = siz;
      simTime = time;
      maxAge = time + age;
    }

    /// <summary>
    /// Simulate object to the given time.
    /// </summary>
    /// <param name="time">Required target time.</param>
    /// <param name="fw">Simulation context.</param>
    /// <returns>False in case of expiry.</returns>
    public bool Simulate ( float time, Fireworks fw )
    {
      if ( time <= simTime )
        return true;

      if ( time > maxAge )
        return false;

      // fly the particle:
      float dt = time - simTime;
      position += dt * velocity;

      simTime = time;

      return true;
    }

    //--- rendering ---

    public override uint Points
    {
      get
      {
        return 1;
      }
    }

    /// <summary>
    /// Points: returns vertex-array size (if ptr is null) or fills vertex array.
    /// </summary>
    /// <param name="ptr">Data pointer (null for determining buffer size).</param>
    /// <param name="origin">Index number in the global vertex array.</param>
    /// <param name="stride">Vertex size (stride) in bytes.</param>
    /// <param name="col">Use color attribute?</param>
    /// <param name="txt">Use txtCoord attribute?</param>
    /// <param name="normal">Use normal vector attribute?</param>
    /// <param name="ptsize">Use point-size/line-width attribute?</param>
    /// <returns>Data size of the vertex-set (in bytes).</returns>
    public override unsafe int PointVertices ( ref float* ptr, ref uint origin, out int stride, bool txt, bool col, bool normal, bool ptsize )
    {
      int total = base.PointVertices( ref ptr, ref origin, out stride, txt, col, normal, ptsize );
      if ( ptr == null )
        return total;

      if ( txt )
        Fill( ref ptr, Vector2.Zero );
      if ( col )
        Fill( ref ptr, ref color );
      if ( normal )
        Fill( ref ptr, ref up );
      if ( ptsize )
        *ptr++ = size;
      Fill( ref ptr, ref position );

      return total;
    }
  }

  /// <summary>
  /// Fireworks instance.
  /// Global framework for the simulation.
  /// </summary>
  public class Fireworks
  {
    /// <summary>
    /// Set of active particles.
    /// </summary>
    List<Particle> particles;

    /// <summary>
    /// New particles (to be added at the end of current simulation frame).
    /// </summary>
    List<Particle> newParticles;

    /// <summary>
    /// Expired particle indices (to be removed at the end of current simulation frame).
    /// </summary>
    List<int> expiredParticles;

    /// <summary>
    /// Set of active launchers.
    /// </summary>
    List<Launcher> launchers;

    public int Launchers
    {
      get
      {
        return launchers.Count;
      }
    }

    public int Particles
    {
      get
      {
        return particles.Count;
      }
    }

    /// <summary>
    /// Maximum number of particles in the simulation.
    /// </summary>
    int maxParticles;

    /// <summary>
    /// This limit is used for render-buffer allocation.
    /// </summary>
    public int MaxParticles
    {
      get
      {
        return maxParticles;
      }
    }

    /// <summary>
    /// This limit is used for render-buffer allocation.
    /// </summary>
    public int MaxLaunchers
    {
      get
      {
        return 20;
      }
    }

    public Particle GetParticle ( int i )
    {
      if ( i < particles.Count )
        return particles[ i ];

      return null;
    }

    public Launcher GetLauncher ( int i )
    {
      if ( i < launchers.Count )
        return launchers[ i ];

      return null;
    }

    /// <summary>
    /// Lock-protected simulation state.
    /// Pause-related stuff could be stored/handled elsewhere.
    /// </summary>
    public bool Running
    {
      get;
      set;
    }

    int frames;

    public int Frames
    {
      get
      {
        return frames;
      }
    }

    float lastTime;

    public float Time
    {
      get
      {
        return lastTime;
      }
    }

    /// <summary>
    /// Slow motion coefficient.
    /// </summary>
    public static double slow = 0.25;

    public Fireworks ( int maxPart = 1000 )
    {
      maxParticles     = maxPart;
      particles        = new List<Particle>( maxParticles );
      newParticles     = new List<Particle>();
      expiredParticles = new List<int>();
      launchers        = new List<Launcher>();
      frames           = 0;
      lastTime         = 0.0f;
      Running          = true;
    }

    /// <summary>
    /// [Re-]initialize the simulation system.
    /// </summary>
    /// <param name="param">User-provided parameter string.</param>
    public void Reset ( string param )
    {
      // input params:
      Dictionary<string, string> p = Util.ParseKeyValueList( param );
      float freq = 10.0f;
      if ( !Util.TryParse( p, "freq", ref freq ) ||
           freq < 1.0f )
        freq = 10.0f;
      if ( !Util.TryParse( p, "max", ref maxParticles ) ||
           maxParticles < 10 )
        maxParticles = 1000;
      if ( !Util.TryParse( p, "slow", ref slow ) ||
           slow < 1.0e-4 )
        slow = 0.25;

      // initialization job itself:
      particles.Clear();
      launchers.Clear();

      AddLauncher( new Launcher( freq ) );

      frames   = 0;
      lastTime = 0.0f;
      Running  = true;
    }

    public void AddLauncher ( Launcher la )
    {
      if ( launchers.Count < MaxLaunchers )
        launchers.Add( la );
    }

    public void AddParticle ( Particle p )
    {
      if ( particles.Count + newParticles.Count - expiredParticles.Count < maxParticles )
        newParticles.Add( p );
    }

    static IComparer<int> ReverseComparer = new Utilities.ReverseComparer<int>();

    /// <summary>
    /// Do one step of simulation.
    /// </summary>
    /// <param name="time">Required target time.</param>
    public void Simulate ( float time )
    {
      if ( !Running )
        return;

      frames++;

      // clean the work table:
      newParticles.Clear();
      expiredParticles.Clear();

      // do the simulation job:
      foreach ( var l in launchers )
        l.Simulate( time, this );
      for ( int i = 0; i < particles.Count; i++ )
        if ( !particles[ i ].Simulate( time, this ) )
          expiredParticles.Add( i );

      // remove expired particles:
      expiredParticles.Sort( ReverseComparer );
      foreach ( int i in expiredParticles )
        particles.RemoveAt( i );

      // add new particles:
      foreach ( var p in newParticles )
        particles.Add( p );

      lastTime = time;
    }

    public unsafe int FillTriangleData ( ref float* ptr, ref uint* iptr, out int stride, bool txt, bool col, bool normal, bool ptsize )
    {
      uint* bakIptr = iptr;
      stride = 0;
      uint origin = 0;

      foreach ( var l in launchers )
      {
        uint bakOrigin = origin;
        l.TriangleVertices( ref ptr, ref origin, out stride, txt, col, normal, ptsize );
        l.TriangleIndices( ref iptr, bakOrigin );
      }

      foreach ( var p in particles )
      {
        uint bakOrigin = origin;
        p.TriangleVertices( ref ptr, ref origin, out stride, txt, col, normal, ptsize );
        p.TriangleIndices( ref iptr, bakOrigin );
      }

      return (int)(iptr - bakIptr);
    }

    public unsafe int FillLineData ( ref float* ptr, ref uint* iptr, out int stride, bool txt, bool col, bool normal, bool ptsize )
    {
      uint* bakIptr = iptr;
      stride = 0;
      uint origin = 0;

      foreach ( var l in launchers )
      {
        uint bakOrigin = origin;
        l.LineVertices( ref ptr, ref origin, out stride, txt, col, normal, ptsize );
        l.LineIndices( ref iptr, bakOrigin );
      }

      foreach ( var p in particles )
      {
        uint bakOrigin = origin;
        p.LineVertices( ref ptr, ref origin, out stride, txt, col, normal, ptsize );
        p.LineIndices( ref iptr, bakOrigin );
      }

      return (int)(iptr - bakIptr);
    }

    public unsafe int FillPointData ( ref float* ptr, out int stride, bool txt, bool col, bool normal, bool ptsize )
    {
      stride = 0;
      uint origin = 0;

      foreach ( var l in launchers )
        l.PointVertices( ref ptr, ref origin, out stride, txt, col, normal, ptsize );

      foreach ( var p in particles )
        p.PointVertices( ref ptr, ref origin, out stride, txt, col, normal, ptsize );

      return (int)origin;
    }
  }

  public partial class Form1
  {
    /// <summary>
    /// Optional form-data initialization.
    /// </summary>
    public static void InitParams ( out string param, out Vector3 center, out float diameter, out bool useNormals, out bool globalColor )
    {
      param = "freq=8000.0,max=60000,slow=0.25";
      center = new Vector3( 0.0f, 1.5f, 0.0f );
      diameter = 5.0f;
      useNormals = false;
      globalColor = false;
    }

    /// <summary>
    /// Can we use shaders?
    /// </summary>
    bool canShaders = false;

    /// <summary>
    /// Are we currently using shaders?
    /// </summary>
    bool useShaders = false;

    uint[] VBOid = null;  // vertex array VBO (colors, normals, coords), index array VBO
    int[] VBOlen = null;  // currently allocated lengths of VBOs

    int stride = 0;       // stride for vertex array
    int indices = 0;      // number of indices for index array

    /// <summary>
    /// Simulation fireworks.
    /// </summary>
    Fireworks fw;

    /// <summary>
    /// Global GLSL program repository.
    /// </summary>
    Dictionary<string, GlProgramInfo> programs = new Dictionary<string, GlProgramInfo>();

    /// <summary>
    /// Current (active) GLSL program.
    /// </summary>
    GlProgram activeProgram = null;

    long lastFpsTime = 0L;
    int frameCounter = 0;
    long primitiveCounter = 0L;
    double lastFps = 0.0;
    double lastPps = 0.0;

    /// <summary>
    /// Function called whenever the main application is idle..
    /// </summary>
    void Application_Idle ( object sender, EventArgs e )
    {
      while ( glControl1.IsIdle )
      {
        glControl1.MakeCurrent();
        Simulate();
        Render();

        long now = DateTime.Now.Ticks;
        if ( now - lastFpsTime > 5000000 )      // more than 0.5 sec
        {
          lastFps = 0.5 * lastFps + 0.5 * (frameCounter     * 1.0e7 / (now - lastFpsTime));
          lastPps = 0.5 * lastPps + 0.5 * (primitiveCounter * 1.0e7 / (now - lastFpsTime));
          lastFpsTime = now;
          frameCounter = 0;
          primitiveCounter = 0L;

          if ( lastPps < 5.0e5 )
            labelFps.Text = String.Format( CultureInfo.InvariantCulture, "Fps: {0:f1}, Pps: {1:f1}k",
                                           lastFps, (lastPps * 1.0e-3) );
          else
            labelFps.Text = String.Format( CultureInfo.InvariantCulture, "Fps: {0:f1}, Pps: {1:f1}m",
                                           lastFps, (lastPps * 1.0e-6) );

          if ( fw != null )
            labelStat.Text = String.Format( CultureInfo.InvariantCulture, "time: {0:f1}s, fr: {1}, laun: {2}, part: {3}",
                                            fw.Time, fw.Frames, fw.Launchers, fw.Particles );
        }
      }
    }

    /// <summary>
    /// OpenGL init code.
    /// </summary>
    void InitOpenGL ()
    {
      // log OpenGL info just for curiosity:
      GlInfo.LogGLProperties();

      // general OpenGL:
      glControl1.VSync = true;
      GL.ClearColor( Color.DarkBlue );
      GL.Enable( EnableCap.DepthTest );
      GL.Enable( EnableCap.VertexProgramPointSize );
      GL.ShadeModel( ShadingModel.Flat );

      // VBO init:
      VBOid = new uint[ 2 ];           // one big buffer for vertex data, another buffer for triangle indices
      GL.GenBuffers( 2, VBOid );
      GlInfo.LogError( "VBO init" );
      VBOlen = new int[ 2 ];           // zeroes..

      // shaders:
      canShaders = SetupShaders();

      // texture:
      GenerateTexture();
    }

    bool SetupShaders ()
    {
      activeProgram = null;

      foreach ( var programInfo in programs.Values )
        if ( programInfo.Setup() )
          activeProgram = programInfo.program;

      if ( activeProgram == null )
        return false;

      GlProgramInfo defInfo;
      if ( programs.TryGetValue( "default", out defInfo ) &&
           defInfo.program != null )
        activeProgram = defInfo.program;

      return true;
    }

    // generated texture:
    const int TEX_SIZE = 128;
    const int TEX_CHECKER_SIZE = 8;
    static Vector3 colWhite = new Vector3( 0.85f, 0.75f, 0.30f );
    static Vector3 colBlack = new Vector3( 0.15f, 0.15f, 0.50f );
    static Vector3 colShade = new Vector3( 0.15f, 0.15f, 0.15f );

    /// <summary>
    /// Texture handle
    /// </summary>
    int texName = 0;

    /// <summary>
    /// Generate the texture.
    /// </summary>
    void GenerateTexture ()
    {
      GL.PixelStore( PixelStoreParameter.UnpackAlignment, 1 );
      texName = GL.GenTexture();
      GL.BindTexture( TextureTarget.Texture2D, texName );

      Vector3[ , ] data = new Vector3[ TEX_SIZE, TEX_SIZE ];
      for ( int y = 0; y < TEX_SIZE; y++ )
        for ( int x = 0; x < TEX_SIZE; x++ )
        {
          bool odd = ((x / TEX_CHECKER_SIZE + y / TEX_CHECKER_SIZE) & 1) > 0;
          data[ y, x ] = odd ? colBlack : colWhite;
          // add some fancy shading on the edges:
          if ( (x % TEX_CHECKER_SIZE) == 0 || (y % TEX_CHECKER_SIZE) == 0 )
            data[ y, x ] += colShade;
          if ( ((x + 1) % TEX_CHECKER_SIZE) == 0 || ((y + 1) % TEX_CHECKER_SIZE) == 0 )
            data[ y, x ] -= colShade;
        }

      GL.TexImage2D( TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, TEX_SIZE, TEX_SIZE, 0, PixelFormat.Rgb, PixelType.Float, data );

      GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat );
      GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat );
      GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear );
      GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMagFilter.Linear );

      GlInfo.LogError( "create-texture" );
    }

    static int Align ( int address )
    {
      return ((address + 15) & -16);
    }

    /// <summary>
    /// Reset VBO buffer's size.
    /// Forces InitDataBuffers() call next time buffers will be needed..
    /// </summary>
    void ResetDataBuffers ()
    {
      VBOlen[ 0 ] = VBOlen[ 1 ] = 0;
    }

    /// <summary>
    /// Initialize VBO buffers.
    /// Determine maximum buffer sizes and allocate VBO objects.
    /// Vertex buffer (max 6 batches):
    /// <list type=">">
    /// <item>launchers - triangles</item>
    /// <item>launchers - lines</item>
    /// <item>launchers - points</item>
    /// <item>particles - triangles</item>
    /// <item>particles - lines</item>
    /// <item>particles - points</item>
    /// </list>
    /// Index buffer (max 4 batches):
    /// <list type=">">
    /// <item>launchers - triangles</item>
    /// <item>launchers - lines</item>
    /// <item>particles - triangles</item>
    /// <item>particles - lines</item>
    /// </list>
    /// </summary>
    unsafe void InitDataBuffers ()
    {
      Particle p;
      Launcher l;
      if ( fw == null ||
           (p = fw.GetParticle( 0 )) == null ||
           (l = fw.GetLauncher( 0 )) == null )
        return;

      // init data buffers for current simulation state (current number of launchers + max number of particles):
      // triangles: determine maximum stride, maximum vertices and indices
      float* ptr = null;
      uint* iptr = null;
      uint origin = 0;

      // vertex-buffer size:
      int maxVB;
      maxVB =                  Align( fw.MaxParticles * p.TriangleVertices( ref ptr, ref origin, out stride, true, true, true, true ) );
      maxVB = Math.Max( maxVB, Align( fw.MaxParticles * p.LineVertices( ref ptr, ref origin, out stride, true, true, true, true ) ) );
      maxVB = Math.Max( maxVB, Align( fw.MaxParticles * p.PointVertices( ref ptr, ref origin, out stride, true, true, true, true ) ) );
      maxVB = Math.Max( maxVB, Align( fw.MaxLaunchers * l.TriangleVertices( ref ptr, ref origin, out stride, true, true, true, true ) ) );
      maxVB = Math.Max( maxVB, Align( fw.MaxLaunchers * l.LineVertices( ref ptr, ref origin, out stride, true, true, true, true ) ) );
      maxVB = Math.Max( maxVB, Align( fw.MaxLaunchers * l.PointVertices( ref ptr, ref origin, out stride, true, true, true, true ) ) );
      // maxVB contains maximal vertex-buffer size for all batches

      // index-buffer size:
      int maxIB;
      maxIB =                  Align( fw.MaxParticles * p.TriangleIndices( ref iptr, 0 ) );
      maxIB = Math.Max( maxIB, Align( fw.MaxParticles * p.LineIndices( ref iptr, 0 ) ) );
      maxIB = Math.Max( maxIB, Align( fw.MaxLaunchers * l.TriangleIndices( ref iptr, 0 ) ) );
      maxIB = Math.Max( maxIB, Align( fw.MaxLaunchers * l.LineIndices( ref iptr, 0 ) ) );
      // maxIB contains maximal index-buffer size for all launchers

      VBOlen[ 0 ] = maxVB;
      VBOlen[ 1 ] = maxIB;

      // Vertex buffer in VBO[ 0 ]:
      GL.BindBuffer( BufferTarget.ArrayBuffer, VBOid[ 0 ] );
      GL.BufferData( BufferTarget.ArrayBuffer, (IntPtr)VBOlen[ 0 ], IntPtr.Zero, BufferUsageHint.DynamicDraw );
      GL.BindBuffer( BufferTarget.ArrayBuffer, 0 );
      GlInfo.LogError( "allocate vertex-buffer" );

      // Index buffer in VBO[ 1 ]:
      GL.BindBuffer( BufferTarget.ElementArrayBuffer, VBOid[ 1 ] );
      GL.BufferData( BufferTarget.ElementArrayBuffer, (IntPtr)VBOlen[ 1 ], IntPtr.Zero, BufferUsageHint.DynamicDraw );
      GL.BindBuffer( BufferTarget.ElementArrayBuffer, 0 );
      GlInfo.LogError( "allocate index-buffer" );
    }

    // appearance:
    Vector3 globalAmbient = new Vector3(   0.2f,  0.2f,  0.2f );
    Vector3 matAmbient    = new Vector3(   1.0f,  0.8f,  0.3f );
    Vector3 matDiffuse    = new Vector3(   1.0f,  0.8f,  0.3f );
    Vector3 matSpecular   = new Vector3(   0.8f,  0.8f,  0.8f );
    float matShininess    = 100.0f;
    Vector3 whiteLight    = new Vector3(   1.0f,  1.0f,  1.0f );
    Vector3 lightPosition = new Vector3( -20.0f, 10.0f, 10.0f );
    Vector3 eyePosition   = new Vector3(   0.0f,  0.0f, 10.0f );

    void SetLightEye ( float size )
    {
      size += size;
      lightPosition = new Vector3( -2.0f * size, size, size );
      eyePosition   = new Vector3(         0.0f, 0.0f, size );
    }

    // attribute/vertex arrays:
    private void SetVertexAttrib ( bool on )
    {
      if ( activeProgram != null )
        if ( on )
          activeProgram.EnableVertexAttribArrays();
        else
          activeProgram.DisableVertexAttribArrays();
    }

    void InitShaderRepository ()
    {
      programs.Clear();
      GlProgramInfo pi;

      // default program:
      pi = new GlProgramInfo( "default", new GlShaderInfo[] {
        new GlShaderInfo( ShaderType.VertexShader, "vertex.glsl", "087fireworks" ),
        new GlShaderInfo( ShaderType.FragmentShader, "fragment.glsl", "087fireworks" ) } );
      programs[ pi.name ] = pi;

      // put more programs here:
      // pi = new GlProgramInfo( ..
      //   ..
      // programs[ pi.name ] = pi;
    }

    /// <summary>
    /// Simulation time of the last checkpoint in system ticks (100ns units)
    /// </summary>
    long ticksLast = DateTime.Now.Ticks;

    /// <summary>
    /// Simulation time of the last checkpoint in seconds.
    /// </summary>
    double timeLast = 0.0;

    /// <summary>
    /// Prime simulation init.
    /// </summary>
    private void InitSimulation ()
    {
      fw = new Fireworks();
      ResetSimulation();
    }

    /// <summary>
    /// [Re-]initialize the simulation.
    /// </summary>
    private void ResetSimulation ()
    {
      if ( fw == null )
        return;

      lock ( fw )
      {
        ResetDataBuffers();
        fw.Reset( textParam.Text );
        ticksLast = DateTime.Now.Ticks;
        timeLast = 0.0;
      }
    }

    /// <summary>
    /// Pause / restart simulation.
    /// </summary>
    private void PauseRestartSimulation ()
    {
      if ( fw == null )
        return;

      lock ( fw )
        fw.Running  = !fw.Running;
    }

    /// <summary>
    /// Simulate one frame.
    /// </summary>
    private void Simulate ()
    {
      if ( fw == null )
        return;

      lock ( fw )
      {
        long nowTicks = DateTime.Now.Ticks;
        if ( nowTicks > ticksLast )
        {
          if ( fw.Running )
          {
            double timeScale = checkSlow.Checked ? Fireworks.slow : 1.0;
            timeLast += (nowTicks - ticksLast) * timeScale * 1.0e-7;
            fw.Simulate( (float)timeLast );
          }
          ticksLast = nowTicks;
        }
      }
    }

    /// <summary>
    /// Render one frame.
    /// </summary>
    private void Render ()
    {
      if ( !loaded )
        return;

      frameCounter++;
      useShaders = canShaders &&
                   activeProgram != null;

      GL.Clear( ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );
      GL.ShadeModel( ShadingModel.Smooth );
      GL.PolygonMode( MaterialFace.FrontAndBack, PolygonMode.Fill );
      GL.Disable( EnableCap.CullFace );

      SetCamera();
      RenderScene();

      glControl1.SwapBuffers();
    }

    /// <summary>
    /// Rendering code itself (separated for clarity).
    /// </summary>
    void RenderScene ()
    {
      if ( useShaders )
      {
        if ( VBOlen[ 0 ] == 0 &&
             VBOlen[ 1 ] == 0 )
          InitDataBuffers();

        if ( VBOlen[ 0 ] > 0 ||
             VBOlen[ 1 ] > 0 )
        {
          // Scene rendering from VBOs:
          SetVertexAttrib( true );

          // using GLSL shaders:
          GL.UseProgram( activeProgram.Id );

          // uniforms:
          Matrix4 modelView = GetModelView();
          Matrix4 modelViewInv = GetModelViewInv();
          Vector3 relEye = Vector3.TransformVector( eyePosition, modelViewInv );
          GL.UniformMatrix4( activeProgram.GetUniform( "matrixModelView" ), false, ref modelView );
          if ( perspective )
            GL.UniformMatrix4( activeProgram.GetUniform( "matrixProjection" ), false, ref perspectiveProjection );
          else
            GL.UniformMatrix4( activeProgram.GetUniform( "matrixProjection" ), false, ref ortographicProjection );

          GL.Uniform3( activeProgram.GetUniform( "globalAmbient" ), ref globalAmbient );
          GL.Uniform3( activeProgram.GetUniform( "lightColor" ), ref whiteLight );
          GL.Uniform3( activeProgram.GetUniform( "lightPosition" ), ref lightPosition );
          GL.Uniform3( activeProgram.GetUniform( "eyePosition" ), ref relEye );
          GL.Uniform3( activeProgram.GetUniform( "Ka" ), ref matAmbient );
          GL.Uniform3( activeProgram.GetUniform( "Kd" ), ref matDiffuse );
          GL.Uniform3( activeProgram.GetUniform( "Ks" ), ref matSpecular );
          GL.Uniform1( activeProgram.GetUniform( "shininess" ), matShininess );

          // color handling:
          bool useColors = !checkGlobalColor.Checked;
          GL.Uniform1( activeProgram.GetUniform( "globalColor" ), useColors ? 0 : 1 );

          // use varying normals?
          bool useNormals = checkNormals.Checked;
          GL.Uniform1( activeProgram.GetUniform( "useNormal" ), useNormals ? 1 : 0 );
          GlInfo.LogError( "set-uniforms" );

          // texture handling:
          bool useTexture = checkTexture.Checked;
          GL.Uniform1( activeProgram.GetUniform( "useTexture" ), useTexture ? 1 : 0 );
          GL.Uniform1( activeProgram.GetUniform( "texSurface" ), 0 );
          if ( useTexture )
          {
            GL.ActiveTexture( TextureUnit.Texture0 );
            GL.BindTexture( TextureTarget.Texture2D, texName );
          }
          GlInfo.LogError( "set-texture" );

          bool usePointSize = true;

          // [txt] [colors] [normals] [ptsize] vertices
          GL.BindBuffer( BufferTarget.ArrayBuffer, VBOid[ 0 ] );
          GL.BindBuffer( BufferTarget.ElementArrayBuffer, VBOid[ 1 ] );

          //-------------------------
          // draw all triangles:

          IntPtr vertexPtr = GL.MapBuffer( BufferTarget.ArrayBuffer, BufferAccess.WriteOnly );
          IntPtr indexPtr = GL.MapBuffer( BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly );
          unsafe
          {
            float* ptr = (float*)vertexPtr.ToPointer();
            uint* iptr = (uint*)indexPtr.ToPointer();
            indices = fw.FillTriangleData( ref ptr, ref iptr, out stride, useTexture, useColors, useNormals, usePointSize );
          }
          GL.UnmapBuffer( BufferTarget.ArrayBuffer );
          GL.UnmapBuffer( BufferTarget.ElementArrayBuffer );
          IntPtr p = IntPtr.Zero;

          if ( indices > 0 )
          {
            if ( activeProgram.HasAttribute( "texCoords" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "texCoords" ), 2, VertexAttribPointerType.Float, false, stride, p );
            if ( useTexture )
              p += Vector2.SizeInBytes;

            if ( activeProgram.HasAttribute( "color" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "color" ), 3, VertexAttribPointerType.Float, false, stride, p );
            if ( useColors )
              p += Vector3.SizeInBytes;

            if ( activeProgram.HasAttribute( "normal" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "normal" ), 3, VertexAttribPointerType.Float, false, stride, p );
            if ( useNormals )
              p += Vector3.SizeInBytes;

            if ( activeProgram.HasAttribute( "ptSize" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "ptSize" ), 1, VertexAttribPointerType.Float, false, stride, p );
            if ( usePointSize )
              p += sizeof( float );

            GL.VertexAttribPointer( activeProgram.GetAttribute( "position" ), 3, VertexAttribPointerType.Float, false, stride, p );
            GlInfo.LogError( "triangles-set-attrib-pointers" );

            // engage!
            GL.DrawElements( PrimitiveType.Triangles, indices, DrawElementsType.UnsignedInt, IntPtr.Zero );
            GlInfo.LogError( "triangles-draw-elements" );

            primitiveCounter += indices / 3;
          }

          //-------------------------
          // draw all lines:

          vertexPtr = GL.MapBuffer( BufferTarget.ArrayBuffer, BufferAccess.WriteOnly );
          indexPtr = GL.MapBuffer( BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly );
          unsafe
          {
            float* ptr = (float*)vertexPtr.ToPointer();
            uint* iptr = (uint*)indexPtr.ToPointer();
            indices = fw.FillLineData( ref ptr, ref iptr, out stride, useTexture, useColors, useNormals, usePointSize );
          }
          GL.UnmapBuffer( BufferTarget.ArrayBuffer );
          GL.UnmapBuffer( BufferTarget.ElementArrayBuffer );

          if ( indices > 0 )
          {
            p = IntPtr.Zero;

            if ( activeProgram.HasAttribute( "texCoords" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "texCoords" ), 2, VertexAttribPointerType.Float, false, stride, p );
            if ( useTexture )
              p += Vector2.SizeInBytes;

            if ( activeProgram.HasAttribute( "color" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "color" ), 3, VertexAttribPointerType.Float, false, stride, p );
            if ( useColors )
              p += Vector3.SizeInBytes;

            if ( activeProgram.HasAttribute( "normal" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "normal" ), 3, VertexAttribPointerType.Float, false, stride, p );
            if ( useNormals )
              p += Vector3.SizeInBytes;

            if ( activeProgram.HasAttribute( "ptSize" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "ptSize" ), 1, VertexAttribPointerType.Float, false, stride, p );
            if ( usePointSize )
              p += sizeof( float );

            GL.VertexAttribPointer( activeProgram.GetAttribute( "position" ), 3, VertexAttribPointerType.Float, false, stride, p );
            GlInfo.LogError( "lines-set-attrib-pointers" );

            // engage!
            GL.DrawElements( PrimitiveType.Lines, indices, DrawElementsType.UnsignedInt, IntPtr.Zero );
            GlInfo.LogError( "lines-draw-elements" );

            primitiveCounter += indices / 2;
          }

          //-------------------------
          // draw all points:

          GL.BindBuffer( BufferTarget.ElementArrayBuffer, 0 );

          vertexPtr = GL.MapBuffer( BufferTarget.ArrayBuffer, BufferAccess.WriteOnly );
          unsafe
          {
            float* ptr = (float*)vertexPtr.ToPointer();
            indices = fw.FillPointData( ref ptr, out stride, useTexture, useColors, useNormals, usePointSize );
          }
          GL.UnmapBuffer( BufferTarget.ArrayBuffer );

          if ( indices > 0 )
          {
            p = IntPtr.Zero;

            if ( activeProgram.HasAttribute( "texCoords" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "texCoords" ), 2, VertexAttribPointerType.Float, false, stride, p );
            if ( useTexture )
              p += Vector2.SizeInBytes;

            if ( activeProgram.HasAttribute( "color" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "color" ), 3, VertexAttribPointerType.Float, false, stride, p );
            if ( useColors )
              p += Vector3.SizeInBytes;

            if ( activeProgram.HasAttribute( "normal" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "normal" ), 3, VertexAttribPointerType.Float, false, stride, p );
            if ( useNormals )
              p += Vector3.SizeInBytes;

            if ( activeProgram.HasAttribute( "ptSize" ) )
              GL.VertexAttribPointer( activeProgram.GetAttribute( "ptSize" ), 1, VertexAttribPointerType.Float, false, stride, p );
            if ( usePointSize )
              p += sizeof( float );

            GL.VertexAttribPointer( activeProgram.GetAttribute( "position" ), 3, VertexAttribPointerType.Float, false, stride, p );
            GlInfo.LogError( "points-set-attrib-pointers" );

            // engage!
            GL.DrawArrays( PrimitiveType.Points, 0, indices );
            GlInfo.LogError( "points-draw-arrays" );

            primitiveCounter += indices;
          }

          GL.BindBuffer( BufferTarget.ArrayBuffer, 0 );
          GL.UseProgram( 0 );

          return;
        }
      }

      // default: draw trivial cube..

      GL.Begin( PrimitiveType.Quads );

      GL.Color3( 0.0f, 1.0f, 0.0f );          // Set The Color To Green
      GL.Vertex3( 1.0f, 1.0f, -1.0f );        // Top Right Of The Quad (Top)
      GL.Vertex3( -1.0f, 1.0f, -1.0f );       // Top Left Of The Quad (Top)
      GL.Vertex3( -1.0f, 1.0f, 1.0f );        // Bottom Left Of The Quad (Top)
      GL.Vertex3( 1.0f, 1.0f, 1.0f );         // Bottom Right Of The Quad (Top)

      GL.Color3( 1.0f, 0.5f, 0.0f );          // Set The Color To Orange
      GL.Vertex3( 1.0f, -1.0f, 1.0f );        // Top Right Of The Quad (Bottom)
      GL.Vertex3( -1.0f, -1.0f, 1.0f );       // Top Left Of The Quad (Bottom)
      GL.Vertex3( -1.0f, -1.0f, -1.0f );      // Bottom Left Of The Quad (Bottom)
      GL.Vertex3( 1.0f, -1.0f, -1.0f );       // Bottom Right Of The Quad (Bottom)

      GL.Color3( 1.0f, 0.0f, 0.0f );          // Set The Color To Red
      GL.Vertex3( 1.0f, 1.0f, 1.0f );         // Top Right Of The Quad (Front)
      GL.Vertex3( -1.0f, 1.0f, 1.0f );        // Top Left Of The Quad (Front)
      GL.Vertex3( -1.0f, -1.0f, 1.0f );       // Bottom Left Of The Quad (Front)
      GL.Vertex3( 1.0f, -1.0f, 1.0f );        // Bottom Right Of The Quad (Front)

      GL.Color3( 1.0f, 1.0f, 0.0f );          // Set The Color To Yellow
      GL.Vertex3( 1.0f, -1.0f, -1.0f );       // Bottom Left Of The Quad (Back)
      GL.Vertex3( -1.0f, -1.0f, -1.0f );      // Bottom Right Of The Quad (Back)
      GL.Vertex3( -1.0f, 1.0f, -1.0f );       // Top Right Of The Quad (Back)
      GL.Vertex3( 1.0f, 1.0f, -1.0f );        // Top Left Of The Quad (Back)

      GL.Color3( 0.0f, 0.0f, 1.0f );          // Set The Color To Blue
      GL.Vertex3( -1.0f, 1.0f, 1.0f );        // Top Right Of The Quad (Left)
      GL.Vertex3( -1.0f, 1.0f, -1.0f );       // Top Left Of The Quad (Left)
      GL.Vertex3( -1.0f, -1.0f, -1.0f );      // Bottom Left Of The Quad (Left)
      GL.Vertex3( -1.0f, -1.0f, 1.0f );       // Bottom Right Of The Quad (Left)

      GL.Color3( 1.0f, 0.0f, 1.0f );          // Set The Color To Violet
      GL.Vertex3( 1.0f, 1.0f, -1.0f );        // Top Right Of The Quad (Right)
      GL.Vertex3( 1.0f, 1.0f, 1.0f );         // Top Left Of The Quad (Right)
      GL.Vertex3( 1.0f, -1.0f, 1.0f );        // Bottom Left Of The Quad (Right)
      GL.Vertex3( 1.0f, -1.0f, -1.0f );       // Bottom Right Of The Quad (Right)

      GL.End();

      primitiveCounter += 12;
    }
  }
}