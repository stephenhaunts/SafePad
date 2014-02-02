/**
 * Safe Pad, a double encrypted note pad that uses 2 passwords to protect your documents and help you keep your privacy.
 * 
 * Copyright (C) 2014 Stephen Haunts
 * http://www.stephenhaunts.com
 * 
 * This file is part of MupenSafe Pad64PlusAE.
 * 
 * Safe Pad is free software: you can redistribute it and/or modify it under the terms of the
 * GNU General Public License as published by the Free Software Foundation, either version 2 of the
 * License, or (at your option) any later version.
 * 
 * Safe Pad is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * 
 * See the GNU General Public License for more details <http://www.gnu.org/licenses/>.
 * 
 * Authors: Stephen Haunts
 */
using System;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public static class RichTextBoxPrinter
    {        
        private const int WmUser = 0x0400;
        private const int EmFormatrange = WmUser + 57;
        private const int Hundredth2Twips = 20*72/100;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Charrange
        {
            internal int cpMin;
            internal int cpMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct Formatrange
        {
            internal IntPtr hdc;
            internal IntPtr hdcTarget;
            internal Rect rc;
            internal Rect rcPage;
            internal Charrange chrg;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct Rect
        {
            internal int Left;
            internal int Top;
            internal int Right;
            internal int Bottom;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "1#")]
        public static bool Print(TextBoxBase box, ref int charFrom, PrintPageEventArgs e)
        {
            if (box == null)
            {
                throw new ArgumentNullException("box");
            }

            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            Formatrange fmtRange;

            IntPtr hdc = e.Graphics.GetHdc();
            fmtRange.hdc = hdc;
            fmtRange.hdcTarget = hdc;
            
            fmtRange.rc.Top = Convert.ToInt32(e.MarginBounds.Top*Hundredth2Twips);
            fmtRange.rc.Bottom = Convert.ToInt32(e.MarginBounds.Bottom*Hundredth2Twips);
            fmtRange.rc.Left = Convert.ToInt32(e.MarginBounds.Left*Hundredth2Twips);
            fmtRange.rc.Right = Convert.ToInt32(e.MarginBounds.Right*Hundredth2Twips);
            
            fmtRange.rcPage.Top = Convert.ToInt32(e.PageBounds.Top*Hundredth2Twips);
            fmtRange.rcPage.Bottom = Convert.ToInt32(e.PageBounds.Bottom*Hundredth2Twips);
            fmtRange.rcPage.Left = Convert.ToInt32(e.PageBounds.Left*Hundredth2Twips);
            fmtRange.rcPage.Right = Convert.ToInt32(e.PageBounds.Right*Hundredth2Twips);
            
            fmtRange.chrg.cpMin = charFrom;
            fmtRange.chrg.cpMax = box.TextLength;
            
            IntPtr hdlRange = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
            Marshal.StructureToPtr(fmtRange, hdlRange, false);
            
            IntPtr res = SendMessage(box.Handle, EmFormatrange, (IntPtr) 1, hdlRange);
            int err = Marshal.GetLastWin32Error();
            
            Marshal.FreeCoTaskMem(hdlRange);
            e.Graphics.ReleaseHdc(hdc);
            
            if (res == IntPtr.Zero)
            {
                throw new InvalidOperationException(string.Format("Printing failed, error code={0}", err));
            }
            
            charFrom = res.ToInt32();
            return charFrom < box.TextLength;
        }        
    }
}