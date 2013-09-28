/**
 * Copyright (c) 2009, https://code.google.com/p/putty-tunnel-manager/
 * Forked 2013 by Perfect-Privacy.com
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace PerfectPrivacy.PPTunnelManager
{
    class FormUtils
    {
        internal static int ValidatePortTextBox(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            int result = -1;
            if (textBox == null || !textBox.Visible ||textBox.Text=="")
                return result;

            try
            {
                result = Int32.Parse(textBox.Text);
                if (result <= 0)
                    throw new FormatException("Value must be positive.");
                if (result >= 65536)
                    throw new FormatException("Value must be smaller than 65536.");

                textBox.BackColor = SystemColors.Window;
            }
            catch (FormatException)
            {
                textBox.BackColor = Color.LightCoral;
                textBox.Focus();

                e.Cancel = true;
            }

            return result;
        }

        internal static string ValidateTextField(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            string result = "enter a valid text";
            if (textBox == null || !textBox.Visible)
                return result;

            if (textBox.Text.Trim() == "")
            {
                textBox.BackColor = Color.LightCoral;
                textBox.Focus();

                e.Cancel = true;
            }
            else
            {
                return textBox.Text.Trim();
            }

            return result;
        }



    }
}
