using System;
using System.Windows.Forms;

namespace LinkedList
{
    
    
    public partial class Form1 : Form
    {
        private readonly Ll _head = new Ll("head");
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = _head.ToString();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text,out _) || !_head.Push(textBox2.Text)) MessageBox.Show("ERROR");
            textBox1.Text = _head.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text,out _) || _head.Remove(textBox2.Text) == null) MessageBox.Show("ERROR");
            textBox1.Text = _head.ToString();
        }
    }

    internal class Ll
    {
        private Ll _next;
        private readonly string _str;

        public Ll(string str)
        {
            _str = str;
        }

        public bool Push(string str)
        {
            if (_str == str)
                return false;
            if (_next != null)
                return _next.Push(str);

            _next = new Ll(str);
            return true;
        }

        public Ll Remove(string str)
        {
            if (str == _str)
            {
                return this;
            }
            
            if (_next == null)
                return null;

            var temp = _next.Remove(str);
            if (temp != null && temp._str == _next._str)//match
            {
                _next = _next._next;
            }
            
            return temp;
        }

        public override string ToString()
        {
            if (_next == null) return _str+" -> null";
            return _str + "->" + _next;
        }
    }
}