using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FocusLineWinForms
{

    public interface IFocusLine
    {
        void DrawFocusLine(IntPtr hWnd, Point startPoint, Point endPoint);
    }

    public class FocusLine : IFocusLine
    {

        #region Native For DrawFocusLine
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int ReleaseDC(HandleRef hWnd, HandleRef hDC);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetDC(HandleRef hWnd);

        [DllImport("gdi32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SelectObject(HandleRef hdc, HandleRef hgdiobj);

        [DllImport("gdi32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetStockObject(int nIndex);

        [DllImport("gdi32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool DeleteObject(HandleRef hObject);

        [DllImport("gdi32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SetROP2(HandleRef hDC, int nDrawMode);

        [DllImport("gdi32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CreatePen(int nStyle, int nWidth, int crColor);

        [DllImport("gdi32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool LineTo(HandleRef hdc, int x, int y);

        [DllImport("gdi32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool MoveToEx(HandleRef hdc, int x, int y, POINT pt);

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;

            public POINT()
            {
            }

            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        /// <devdoc>
        ///     This makes a choice from a set of raster op codes, based on the color given.  If the
        ///     color is considered to be "dark", the raster op provided by dark will be returned.
        /// </devdoc>
        private static int GetColorRop(Color color, int darkROP, int lightROP)
        {
            if (color.GetBrightness() < .5)
            {
                return darkROP;
            }
            return lightROP;
        }
        #endregion

        private Rectangle LastDrawLinePoint = new Rectangle(-1, -1, -1, 0);

        private Point lastReversibleLineStart = new Point(-1, -1);
        private Point lastReversibleLineEnd = new Point(-1, -1);


        public void DrawFocusLine(IntPtr hWnd, Point startPoint, Point endPoint)
        {
            DrawReversibleLine(hWnd, startPoint, endPoint, Color.Black);

            lastReversibleLineStart = startPoint;
            lastReversibleLineEnd = endPoint;
        }


        private void DrawReversibleLine(IntPtr hWnd, Point start, Point end, Color backColor)
        {

            const int PS_SOLID = 0, PS_DOT = 2, BS_SOLID = 0, HOLLOW_BRUSH = 5;

            int rop2 = GetColorRop(backColor, 0xA, 0x7);

            IntPtr dc = GetDC(new HandleRef(null, hWnd));
            IntPtr pen = CreatePen(PS_DOT, 1, ColorTranslator.ToWin32(backColor));

            int prevRop2 = SetROP2(new HandleRef(null, dc), rop2);
            IntPtr oldBrush = SelectObject(new HandleRef(null, dc), new HandleRef(null, GetStockObject(HOLLOW_BRUSH)));
            IntPtr oldPen = SelectObject(new HandleRef(null, dc), new HandleRef(null, pen));

            MoveToEx(new HandleRef(null, dc), start.X, start.Y, null);
            LineTo(new HandleRef(null, dc), end.X, end.Y);

            SetROP2(new HandleRef(null, dc), prevRop2);
            SelectObject(new HandleRef(null, dc), new HandleRef(null, oldBrush));
            SelectObject(new HandleRef(null, dc), new HandleRef(null, oldPen));
            DeleteObject(new HandleRef(null, pen));
            ReleaseDC(new HandleRef(null, IntPtr.Zero), new HandleRef(null, dc));
        }
    }


    public class FocusRect : IFocusLine
    {


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool DrawFocusRect(IntPtr hDC, ref RECT lprc);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int ReleaseDC(HandleRef hWnd, HandleRef hDC);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetDC(HandleRef hWnd);



        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            int LEFT;
            int TOP;
            int RIGHT;
            int BOTTOM;

            public RECT(int left, int top, int right, int bottom)
            {
                LEFT = left;
                TOP = top;
                RIGHT = right;
                BOTTOM = bottom;
            }
        }


        public void DrawFocusLine(IntPtr hwnd, Point startPoint, Point endPoint)
        {

            var rect = new RECT(
                startPoint.X < endPoint.X ? startPoint.X : endPoint.X,
                startPoint.Y < endPoint.Y ? startPoint.Y : endPoint.Y,
                startPoint.X >= endPoint.X ? startPoint.X : endPoint.X,
                startPoint.Y >= endPoint.Y ? startPoint.Y : endPoint.Y
                );

            DrawReversibleRect(hwnd, ref rect);
        }

        private void DrawReversibleRect(IntPtr hWnd, ref RECT rect) { 

            IntPtr dc = GetDC(new HandleRef(null, hWnd));
            DrawFocusRect(dc, ref rect);
            ReleaseDC(new HandleRef(null, IntPtr.Zero), new HandleRef(null, dc));
        }


    }

}
