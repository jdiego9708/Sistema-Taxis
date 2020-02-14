using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class CustomTextBox : UserControl
    {
        public CustomTextBox()
        {
            InitializeComponent();

            this.Load += CustomTextBox_Load;

            this.txtBusqueda.LostFocus += TxtBusqueda_LostFocus;
            this.txtBusqueda.GotFocus += TxtBusqueda_GotFocus;
            this.txtBusqueda.TextChanged += TxtBusqueda_TextChanged;
            this.txtBusqueda.SizeChanged += TxtBusqueda_SizeChanged;
            this.txtBusqueda.KeyPress += TxtBusqueda_KeyPress;
        }

        #region EVENTOS 
        public event EventHandler OnCustomLostFocus;
        public event EventHandler OnPxClick;
        public event KeyPressEventHandler OnCustomKeyPress;

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            this.Texto = txt.Text;
            if (txt.Text.Equals("") || txt.Text.Equals(this.Texto_inicial))
            {
                txt.Font =
                        new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
                txt.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else
            {
                txt.Font =
                        new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                txt.ForeColor = Color.Black;
                OnTextoChanged?.Invoke(sender, e);
            }
        }

        private void TxtBusqueda_SizeChanged(object sender, EventArgs e)
        {
            this.ConfigImage(this.Visible_px);
        }

        private void Px_Click(object sender, EventArgs e)
        {
            this.OnPxClick?.Invoke(this, e);
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnCustomKeyPress?.Invoke(this, e);
        }

        private void TxtBusqueda_LostFocus(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.Silver;
            if (this.txtBusqueda.Text.Equals("") | this.txtBusqueda.Text.Equals(this.Texto_inicial))
            {
                this.txtBusqueda.Text = this.Texto_inicial;
            }
            this.OnCustomLostFocus?.Invoke(this, e);
        }

        private void TxtBusqueda_GotFocus(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.Teal;
            if (this.txtBusqueda.Text.Equals(this.Texto_inicial))
            {
                this.txtBusqueda.Clear();
            }
        }

        #endregion

        PictureBox px;

        #region PROPIEDADES PERSONALIZADAS

        public event EventHandler OnTextoInicialChanged;
        public event EventHandler OnTextoChanged;
        public event EventHandler OnPxVisibleChanged;
        public event EventHandler OnImagenChanged;
        private event EventHandler _OnPrivateTextoInicialChanged;
        private event EventHandler _OnPrivateTextoChanged;
        private event EventHandler _OnPrivateVisiblePxChanged;
        private event EventHandler _OnPrivateImagenChanged;
        private string texto;
        private string texto_inicial;
        private bool _visible_px = true;
        private Image _imagen;
        private string _tipo_txt;
        private int _maxLenght;

        public string Texto_inicial
        {
            get
            {
                return texto_inicial;
            }
            set
            {
                if (value != texto_inicial)
                {
                    texto_inicial = value;
                    _OnPrivateTextoInicialChanged += CustomTextBox_OnTextoInicialChanged;
                    _OnPrivateTextoInicialChanged(value, null);
                }
            }
        }
        public string Texto
        {
            get
            {
                return texto;
            }
            set
            {
                if (value != texto)
                {
                    texto = value;
                    if (!value.Equals(""))
                    {
                        _OnPrivateTextoChanged += CustomTextBox_OnTextoChanged;
                        _OnPrivateTextoChanged(value, null);
                    }
                }
            }
        }
        public bool Visible_px
        {
            get
            {
                return _visible_px;
            }
            set
            {
                if (value != _visible_px)
                {
                    _visible_px = value;
                    _OnPrivateVisiblePxChanged += CustomTextBox__OnPrivateVisiblePxChanged;
                    _OnPrivateVisiblePxChanged(value, null);
                }
            }
        }
        public Image Imagen
        {
            get
            {
                return _imagen;
            }
            set
            {
                if (value != _imagen)
                {
                    _imagen = value;
                    _OnPrivateImagenChanged += CustomTextBox__OnPrivateImagenChanged;
                    _OnPrivateImagenChanged(value, null);
                }
            }
        }
        public string Tipo_txt
        {
            get
            {
                return _tipo_txt;
            }
            set
            {
                _tipo_txt = value;
            }
        }
        public int MaxLenght { get => _maxLenght; set => _maxLenght = value; }
        #endregion

        #region EVENTOS DE PROPIEDADES

        private void CustomTextBox__OnPrivateImagenChanged(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            if (image != null & this.px != null)
            {
                this.px.Image = image;
                OnImagenChanged?.Invoke(sender, e);
            }
        }

        private void CustomTextBox__OnPrivateVisiblePxChanged(object sender, EventArgs e)
        {
            this.ConfigImage(this.Visible_px);
        }

        private void CustomTextBox_OnTextoChanged(object sender, EventArgs e)
        {
            this.OnTextoChanged?.Invoke(this, e);
        }

        private void CustomTextBox_OnTextoInicialChanged(object sender, EventArgs e)
        {
            this.txtBusqueda.Text = this.Texto_inicial;
            OnTextoInicialChanged?.Invoke(this, e);
        }

        #endregion

        private void ConfigImage(bool visible)
        {
            TextBox txt = txtBusqueda;
            if (this.px != null)
            {
                this.panel1.Controls.Remove(px);
            }

            if (visible)
            {
                Image img;
                if (this.Imagen != null)
                    img = this.Imagen;
                else
                    img = Properties.Resources.lupa;

                int size = txt.Height;
                this.px = new PictureBox()
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = img,
                    Size = new Size(size, size),
                    Location =
                    new Point(txt.Width - size, txt.Location.Y),
                    Cursor = Cursors.Hand,
                };
                this.px.Click += Px_Click;
                this.panel1.Controls.Add(px);
                px.BringToFront();
                OnPxVisibleChanged?.Invoke(null, null);
            }
        }

        private void CustomTextBox_Load(object sender, EventArgs e)
        {
            if (this.MaxLenght != 0)
                this.txtBusqueda.MaxLength = this.MaxLenght;

            this.txtBusqueda.Text = this.Texto_inicial;
            if (this.Texto != null)
            {
                this.txtBusqueda.Text = this.Texto;
            }
            this.ConfigImage(true);
        }
    }
}
