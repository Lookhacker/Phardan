using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace PharmedPlastPouyan
{
    public class LEDSize1 : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath myPath = new GraphicsPath();
            Rectangle pathRect = new Rectangle(03, 020, 930, 1510);
            myPath.AddRectangle(pathRect);
            pathRect = new Rectangle(130, 120,730, 1320);
            myPath.AddRectangle(pathRect);
            this.Region = new System.Drawing.Region(myPath);


            base.OnPaint(pe);

        }
    }
    public class LEDSize2 : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath myPath = new GraphicsPath();
            Rectangle pathRect = new Rectangle(00, 000, 900, 2000);
            myPath.AddRectangle(pathRect);
            pathRect = new Rectangle(100, 100,700, 1800);
            myPath.AddRectangle(pathRect);
            this.Region = new System.Drawing.Region(myPath);


            base.OnPaint(pe);

        }
    }
    public class LEDSize3 : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            //GraphicsPath mmp = new GraphicsPath();
            //mmp.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            //this.Region = new System.Drawing.Region(mmp);

            //GraphicsPath myPath = new GraphicsPath();
            //myPath.AddLine(0, 0, 50, 50);
            //myPath.AddLine(50, 50, 100, 0);
            //myPath.AddLine(100, 0, 100, 30);
            //myPath.AddLine(100, 30, 50, 80);
            //myPath.AddLine(50, 80, 0, 30);

            GraphicsPath myPath = new GraphicsPath();
            Rectangle pathRect = new Rectangle(02, 030, 1540, 2400);
            myPath.AddRectangle(pathRect);
            pathRect = new Rectangle(130, 101,1230, 1480);
            myPath.AddRectangle(pathRect);
            this.Region = new System.Drawing.Region(myPath);


            base.OnPaint(pe);

        }
    }
}
