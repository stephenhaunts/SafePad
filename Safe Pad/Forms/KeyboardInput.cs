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
        
        private bool _capsLock = false;

        public KeyboardInput()
        {
            InitializeComponent();
        }

        public string Password
        {
            get
            {
                return _maskedPassword.Text;
            }
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
            _underscore.Text = "-";
            _equals.Text = "=";
            _leftSquareBracket.Text = "[";
            _rightSquareBracket.Text = "]";
            _semiColon.Text = ";";
            _apostophe.Text = "'";
            _hash.Text = "#";
            _comma.Text = ",";
            _fullStop.Text = ".";
            _forwardSlash.Text = "/";
            _backSlash.Text = @"\";
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
            _underscore.Text = "_";
            _equals.Text = "+";
            _leftSquareBracket.Text = "{";
            _rightSquareBracket.Text = "}";
            _semiColon.Text = ":";
            _apostophe.Text = "@";
            _hash.Text = "~";
            _comma.Text = "<";
            _fullStop.Text = ">";
            _forwardSlash.Text = "?";
            _backSlash.Text = "|";
        }
        private void ApplyButtonTextToPassword(object sender)
        {
            _maskedPassword.Text = _maskedPassword.Text + ((Button)sender).Text;
        }

        private void _1_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _2_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _3_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _4_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _5_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _6_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _7_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _8_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _9_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _0_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _underscore_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _equals_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _q_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _w_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _e_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _r_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _t_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _y_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _u_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _i_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _o_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _p_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _leftSquareBracket_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _rightSquareBracket_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _a_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _s_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _d_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _f_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _g_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _h_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _j_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _k_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _l_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _semiColon_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _apostophe_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _hash_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _backSlash_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _z_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _x_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _c_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _v_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _b_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _n_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _m_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _comma_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _fullStop_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _forwardSlash_Click(object sender, EventArgs e)
        {
            ApplyButtonTextToPassword(sender);
        }

        private void _spaceBar_Click(object sender, EventArgs e)
        {
            _maskedPassword.Text = _maskedPassword.Text + " ";
        }

        private void _backSpace_Click(object sender, EventArgs e)
        {
            if (_maskedPassword.Text.Length > 0)
            {
                _maskedPassword.Text = _maskedPassword.Text.Substring(0, _maskedPassword.Text.Length - 1);
            }
        }
    }
}
