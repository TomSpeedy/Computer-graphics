﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Raster;
using System.Globalization;
using System.Diagnostics;
using Utilities;

namespace _081fullcolor
{
  public partial class Form1 : Form
  {
    protected Bitmap inputImage = null;
    protected Bitmap outputImage = null;

    public Form1 ()
    {
      InitializeComponent();
      string par;
      Generator.InitParams( out par );
      textParam.Text = par;

      String[] tok = "$Rev$".Split( ' ' );
      Text += " (rev: " + tok[ 1 ] + ')';
    }

    protected Thread aThread = null;

    volatile public static bool cont = true;

    delegate void SetImageCallback ( Bitmap newImage );

    protected void SetImage ( Bitmap newImage )
    {
      if ( pictureBox1.InvokeRequired )
      {
        SetImageCallback si = new SetImageCallback( SetImage );
        BeginInvoke( si, new object[] { newImage } );
      }
      else
      {
        pictureBox1.Image = newImage;
        pictureBox1.Invalidate();
      }
    }

    delegate void SetTextCallback ( string text );

    protected void SetText ( string text )
    {
      if ( labelElapsed.InvokeRequired )
      {
        SetTextCallback st = new SetTextCallback( SetText );
        BeginInvoke( st, new object[] { text } );
      }
      else
        labelElapsed.Text = text;
    }

    private void buttonOpen_Click ( object sender, EventArgs e )
    {
      OpenFileDialog ofd = new OpenFileDialog();

      ofd.Title = "Open Image File";
      ofd.Filter = "Bitmap Files|*.bmp" +
          "|Gif Files|*.gif" +
          "|JPEG Files|*.jpg" +
          "|PNG Files|*.png" +
          "|TIFF Files|*.tif" +
          "|All image types|*.bmp;*.gif;*.jpg;*.png;*.tif";

      ofd.FilterIndex = 6;
      ofd.FileName = "";
      if ( ofd.ShowDialog() != DialogResult.OK )
      {
        if ( inputImage != null )
          inputImage.Dispose();

        inputImage = null;
        recompute();
        return;
      }

      newImage( ofd.FileName );
    }

    /// <summary>
    /// Sets the new image defined by its file-name. Does all the checks.
    /// </summary>
    private bool newImage ( string fn )
    {
      Image inp = null;
      try
      {
        inp = Image.FromFile( fn );
      }
      catch ( Exception )
      {
        return false;
      }

      if ( inputImage != null )
        inputImage.Dispose();
      inputImage = new Bitmap( inp );

      if ( outputImage != null )
        outputImage.Dispose();
      outputImage = null;

      inp.Dispose();
      recompute();

      return true;
    }

    protected void EnableGUI ( bool enable )
    {
      buttonRedraw.Enabled = enable;
      buttonOpen.Enabled = enable;
      buttonSave.Enabled = enable;
      textParam.Enabled = enable;
      checkFast.Enabled = enable;
      buttonStop.Enabled = !enable;
    }

    delegate void StopComputationCallback ();

    protected void StopComputation ()
    {
      if ( aThread == null )
        return;

      if ( buttonRedraw.InvokeRequired )
      {
        StopComputationCallback ea = new StopComputationCallback( StopComputation );
        BeginInvoke( ea );
      }
      else
      {
        // actually stop the computation:
        cont = false;
        aThread.Join();
        aThread = null;

        // GUI stuff:
        EnableGUI( true );
      }
    }

    private void transform ()
    {
      Bitmap ibmp = inputImage;
      Bitmap bmp;
      Stopwatch sw = new Stopwatch();
      sw.Start();

      Generator.Recompute( ibmp, out bmp, checkFast.Checked, textParam.Text );

      sw.Stop();
      float elapsed = 1.0e-3f * sw.ElapsedMilliseconds;
      long missing = (1 << 24) - Draw.ColorNumber( bmp );

      SetImage( bmp );
      if ( outputImage != null )
        outputImage.Dispose();
      outputImage = bmp;

      SetText( string.Format( CultureInfo.InvariantCulture, "Elapsed: {0:f3}s - {1}", elapsed, (missing > 0) ? missing.ToString() : "Ok" ) );

      StopComputation();
    }

    private void recompute ()
    {
      if ( aThread != null )
        return;

      EnableGUI( false );
      cont = true;

      aThread = new Thread( new ThreadStart( this.transform ) );
      aThread.Start();
    }

    private void buttonSave_Click ( object sender, EventArgs e )
    {
      if ( outputImage == null ) return;

      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Title = "Save PNG file";
      sfd.Filter = "PNG Files|*.png";
      sfd.AddExtension = true;
      sfd.FileName = "";
      sfd.ShowDialog();

      if ( sfd.FileName == "" )
        return;

      outputImage.Save( sfd.FileName, System.Drawing.Imaging.ImageFormat.Png );
    }

    private void buttonRedraw_Click ( object sender, EventArgs e )
    {
      recompute();
    }

    private void buttonStop_Click ( object sender, EventArgs e )
    {
      StopComputation();
    }

    private void Form1_DragDrop ( object sender, DragEventArgs e )
    {
      string[] strFiles = (string[])e.Data.GetData( DataFormats.FileDrop );
      newImage( strFiles[ 0 ] );
    }

    private void Form1_DragEnter ( object sender, DragEventArgs e )
    {
      if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
        e.Effect = DragDropEffects.Copy;
    }
  }
}