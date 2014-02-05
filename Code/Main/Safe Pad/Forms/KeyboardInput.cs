/**
 * Safe Pad, a double encrypted note pad that uses 2 passwords to protect your documents and help you keep your privacy.
 * 
 * Copyright (C) 2014 Stephen Haunts
 * http://www.stephenhaunts.com
 * 
 * This file is part of Safe Pad.
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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HauntedHouseSoftware.SecureNotePad.Forms
{    
    public partial class KeyboardInput : Form
    {
        private string _password;
        private bool _capsLock = false;

        public KeyboardInput()
        {
            InitializeComponent();
        }

        private void _caps_Click(object sender, EventArgs e)
        {
            _capsLock = !_capsLock;
            

            if (_capsLock)            
            {
                SetCapsLock();               
            }
            else
            {
                UnsetCapsLock();
            }
        }

        private void UnsetCapsLock()
        {
            _caps.BackColor = Color.WhiteSmoke;
            _q.Text = "q";
            _w.Text = "w";
            _e.Text = "e";
            _r.Text = "r";
            _t.Text = "t";
            _y.Text = "y";
            _u.Text = "u";
            _i.Text = "i";
            _o.Text = "o";
            _p.Text = "p";

            _a.Text = "a";
            _s.Text = "s";
            _d.Text = "d";
            _f.Text = "f";
            _g.Text = "g";
            _h.Text = "h";
            _j.Text = "j";
            _k.Text = "k";
            _l.Text = "l";

            _z.Text = "z";
            _x.Text = "x";
            _c.Text = "c";
            _v.Text = "v";
            _b.Text = "b";
            _n.Text = "n";
            _m.Text = "m";

            _1.Text = "1";
            _2.Text = "2";
            _3.Text = "3";
            _4.Text = "4";
            _5.Text = "5";
            _6.Text = "6";
            _7.Text = "7";
            _8.Text = "8";
            _9.Text = "9";
            _0.Text = "0";
        }

        private void SetCapsLock()
        {
            _caps.BackColor = Color.DarkGray;
            _q.Text = "Q";
            _w.Text = "W";
            _e.Text = "E";
            _r.Text = "R";
            _t.Text = "T";
            _y.Text = "Y";
            _u.Text = "U";
            _i.Text = "I";
            _o.Text = "O";
            _p.Text = "P";

            _a.Text = "A";
            _s.Text = "S";
            _d.Text = "D";
            _f.Text = "F";
            _g.Text = "G";
            _h.Text = "H";
            _j.Text = "J";
            _k.Text = "K";
            _l.Text = "L";

            _z.Text = "Z";
            _x.Text = "X";
            _c.Text = "C";
            _v.Text = "V";
            _b.Text = "B";
            _n.Text = "N";
            _m.Text = "M";

            _1.Text = "!";
            _2.Text = @"""";
            _3.Text = "£";
            _4.Text = "$";
            _5.Text = "%";
            _6.Text = "^";
            _7.Text = "&&";
            _8.Text = "*";
            _9.Text = "(";
            _0.Text = ")";
        }

    }
}
