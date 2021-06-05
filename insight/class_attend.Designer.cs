
namespace Education_Center
{
    partial class class_attend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(class_attend));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_code = new Guna.UI.WinForms.GunaTextBox();
            this.txt_date = new Guna.UI.WinForms.GunaDateTimePicker();
            this.dropdown_sub = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.txt_datel = new Bunifu.UI.WinForms.BunifuLabel();
            this.dropdown_subl = new Bunifu.UI.WinForms.BunifuLabel();
            this.btn_norecord = new Guna.UI.WinForms.GunaGradientTileButton();
            this.bunifuButton2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.grid_attend = new Bunifu.UI.WinForms.BunifuDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grid_attend)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_code
            // 
            this.txt_code.BaseColor = System.Drawing.Color.White;
            this.txt_code.BorderColor = System.Drawing.Color.Silver;
            this.txt_code.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_code.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_code.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_code.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_code.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_code.Location = new System.Drawing.Point(38, 70);
            this.txt_code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_code.Name = "txt_code";
            this.txt_code.PasswordChar = '\0';
            this.txt_code.SelectedText = "";
            this.txt_code.Size = new System.Drawing.Size(219, 32);
            this.txt_code.TabIndex = 0;
            this.txt_code.TextChanged += new System.EventHandler(this.txt_code_TextChanged);
            // 
            // txt_date
            // 
            this.txt_date.BaseColor = System.Drawing.Color.White;
            this.txt_date.BorderColor = System.Drawing.Color.Silver;
            this.txt_date.CustomFormat = null;
            this.txt_date.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.txt_date.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_date.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_date.ForeColor = System.Drawing.Color.Black;
            this.txt_date.Location = new System.Drawing.Point(283, 70);
            this.txt_date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txt_date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txt_date.Name = "txt_date";
            this.txt_date.OnHoverBaseColor = System.Drawing.Color.White;
            this.txt_date.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_date.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_date.OnPressedColor = System.Drawing.Color.Black;
            this.txt_date.Size = new System.Drawing.Size(233, 32);
            this.txt_date.TabIndex = 1;
            this.txt_date.Text = "Thursday, April 29, 2021";
            this.txt_date.Value = new System.DateTime(2021, 4, 29, 20, 52, 3, 117);
            this.txt_date.ValueChanged += new System.EventHandler(this.txt_date_ValueChanged);
            // 
            // dropdown_sub
            // 
            this.dropdown_sub.BackColor = System.Drawing.Color.White;
            this.dropdown_sub.BorderRadius = 1;
            this.dropdown_sub.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.dropdown_sub.DisabledColor = System.Drawing.Color.Gray;
            this.dropdown_sub.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dropdown_sub.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.dropdown_sub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdown_sub.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dropdown_sub.FillDropDown = false;
            this.dropdown_sub.FillIndicator = false;
            this.dropdown_sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdown_sub.ForeColor = System.Drawing.Color.Purple;
            this.dropdown_sub.FormattingEnabled = true;
            this.dropdown_sub.Icon = null;
            this.dropdown_sub.IndicatorColor = System.Drawing.Color.Purple;
            this.dropdown_sub.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dropdown_sub.ItemBackColor = System.Drawing.Color.White;
            this.dropdown_sub.ItemBorderColor = System.Drawing.Color.White;
            this.dropdown_sub.ItemForeColor = System.Drawing.Color.Purple;
            this.dropdown_sub.ItemHeight = 26;
            this.dropdown_sub.ItemHighLightColor = System.Drawing.Color.Thistle;
            this.dropdown_sub.Location = new System.Drawing.Point(534, 70);
            this.dropdown_sub.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dropdown_sub.Name = "dropdown_sub";
            this.dropdown_sub.Size = new System.Drawing.Size(217, 32);
            this.dropdown_sub.TabIndex = 2;
            this.dropdown_sub.Text = null;
            this.dropdown_sub.SelectedIndexChanged += new System.EventHandler(this.dropdown_sub_SelectedIndexChanged);
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.AllowToggling = false;
            this.bunifuButton1.AnimationSpeed = 200;
            this.bunifuButton1.AutoGenerateColors = false;
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.ButtonText = "SEARCH STIDENT";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.ColorContrastOnClick = 45;
            this.bunifuButton1.ColorContrastOnHover = 45;
            this.bunifuButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.bunifuButton1.CustomizableEdges = borderEdges1;
            this.bunifuButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton1.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton1.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton1.IconMarginLeft = 11;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton1.IdleBorderRadius = 3;
            this.bunifuButton1.IdleBorderThickness = 1;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.IndicateFocus = false;
            this.bunifuButton1.Location = new System.Drawing.Point(887, 53);
            this.bunifuButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuButton1.Name = "bunifuButton1";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties1.BorderRadius = 3;
            stateProperties1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties1.ForeColor = System.Drawing.Color.White;
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.bunifuButton1.onHoverState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.BorderRadius = 3;
            stateProperties2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties2.BorderThickness = 1;
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.ForeColor = System.Drawing.Color.White;
            stateProperties2.IconLeftImage = null;
            stateProperties2.IconRightImage = null;
            this.bunifuButton1.OnPressedState = stateProperties2;
            this.bunifuButton1.Size = new System.Drawing.Size(210, 59);
            this.bunifuButton1.TabIndex = 3;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.TextMarginLeft = 0;
            this.bunifuButton1.UseDefaultRadiusAndThickness = true;
            this.bunifuButton1.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // guna2VScrollBar1
            // 
            this.guna2VScrollBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.guna2VScrollBar1.HoverState.Parent = null;
            this.guna2VScrollBar1.LargeChange = 10;
            this.guna2VScrollBar1.Location = new System.Drawing.Point(1184, 348);
            this.guna2VScrollBar1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.guna2VScrollBar1.MouseWheelBarPartitions = 10;
            this.guna2VScrollBar1.Name = "guna2VScrollBar1";
            this.guna2VScrollBar1.PressedState.Parent = this.guna2VScrollBar1;
            this.guna2VScrollBar1.ScrollbarSize = 24;
            this.guna2VScrollBar1.Size = new System.Drawing.Size(24, 658);
            this.guna2VScrollBar1.TabIndex = 5;
            this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2VScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.guna2VScrollBar1_Scroll);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.Location = new System.Drawing.Point(38, 33);
            this.bunifuLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(88, 18);
            this.bunifuLabel1.TabIndex = 6;
            this.bunifuLabel1.Text = "Student index no :";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txt_datel
            // 
            this.txt_datel.AutoEllipsis = false;
            this.txt_datel.CursorType = null;
            this.txt_datel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_datel.Location = new System.Drawing.Point(283, 33);
            this.txt_datel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_datel.Name = "txt_datel";
            this.txt_datel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_datel.Size = new System.Drawing.Size(26, 15);
            this.txt_datel.TabIndex = 7;
            this.txt_datel.Text = "Date";
            this.txt_datel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txt_datel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // dropdown_subl
            // 
            this.dropdown_subl.AutoEllipsis = false;
            this.dropdown_subl.CursorType = null;
            this.dropdown_subl.Enabled = false;
            this.dropdown_subl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdown_subl.Location = new System.Drawing.Point(534, 33);
            this.dropdown_subl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dropdown_subl.Name = "dropdown_subl";
            this.dropdown_subl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dropdown_subl.Size = new System.Drawing.Size(45, 15);
            this.dropdown_subl.TabIndex = 8;
            this.dropdown_subl.Text = "Subject :";
            this.dropdown_subl.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.dropdown_subl.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btn_norecord
            // 
            this.btn_norecord.AnimationHoverSpeed = 0.07F;
            this.btn_norecord.AnimationSpeed = 0.03F;
            this.btn_norecord.BaseColor1 = System.Drawing.Color.DodgerBlue;
            this.btn_norecord.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_norecord.BorderColor = System.Drawing.Color.Black;
            this.btn_norecord.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_norecord.FocusedColor = System.Drawing.Color.Empty;
            this.btn_norecord.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_norecord.ForeColor = System.Drawing.Color.White;
            this.btn_norecord.Image = global::Education_Center.Properties.Resources.erroricon;
            this.btn_norecord.ImageSize = new System.Drawing.Size(52, 52);
            this.btn_norecord.Location = new System.Drawing.Point(260, 263);
            this.btn_norecord.Name = "btn_norecord";
            this.btn_norecord.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btn_norecord.OnHoverBaseColor2 = System.Drawing.Color.White;
            this.btn_norecord.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_norecord.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_norecord.OnHoverImage = null;
            this.btn_norecord.OnPressedColor = System.Drawing.Color.Black;
            this.btn_norecord.Size = new System.Drawing.Size(256, 160);
            this.btn_norecord.TabIndex = 14;
            this.btn_norecord.Text = "No attendace found !";
            this.btn_norecord.Click += new System.EventHandler(this.btn_norecord_Click);
            // 
            // bunifuButton2
            // 
            this.bunifuButton2.AllowToggling = false;
            this.bunifuButton2.AnimationSpeed = 200;
            this.bunifuButton2.AutoGenerateColors = false;
            this.bunifuButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton2.BackColor1 = System.Drawing.Color.Blue;
            this.bunifuButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton2.BackgroundImage")));
            this.bunifuButton2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton2.ButtonText = ">";
            this.bunifuButton2.ButtonTextMarginLeft = 0;
            this.bunifuButton2.ColorContrastOnClick = 45;
            this.bunifuButton2.ColorContrastOnHover = 45;
            this.bunifuButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.bunifuButton2.CustomizableEdges = borderEdges2;
            this.bunifuButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton2.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuButton2.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton2.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton2.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton2.ForeColor = System.Drawing.Color.White;
            this.bunifuButton2.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton2.IconMarginLeft = 11;
            this.bunifuButton2.IconPadding = 10;
            this.bunifuButton2.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton2.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton2.IdleBorderRadius = 3;
            this.bunifuButton2.IdleBorderThickness = 1;
            this.bunifuButton2.IdleFillColor = System.Drawing.Color.Blue;
            this.bunifuButton2.IdleIconLeftImage = null;
            this.bunifuButton2.IdleIconRightImage = null;
            this.bunifuButton2.IndicateFocus = false;
            this.bunifuButton2.Location = new System.Drawing.Point(757, 70);
            this.bunifuButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bunifuButton2.Name = "bunifuButton2";
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.BorderRadius = 3;
            stateProperties3.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties3.BorderThickness = 1;
            stateProperties3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.ForeColor = System.Drawing.Color.White;
            stateProperties3.IconLeftImage = null;
            stateProperties3.IconRightImage = null;
            this.bunifuButton2.onHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties4.BorderRadius = 3;
            stateProperties4.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties4.BorderThickness = 1;
            stateProperties4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties4.ForeColor = System.Drawing.Color.White;
            stateProperties4.IconLeftImage = null;
            stateProperties4.IconRightImage = null;
            this.bunifuButton2.OnPressedState = stateProperties4;
            this.bunifuButton2.Size = new System.Drawing.Size(34, 32);
            this.bunifuButton2.TabIndex = 15;
            this.bunifuButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton2.TextMarginLeft = 0;
            this.bunifuButton2.UseDefaultRadiusAndThickness = true;
            this.bunifuButton2.Click += new System.EventHandler(this.bunifuButton2_Click);
            // 
            // grid_attend
            // 
            this.grid_attend.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.grid_attend.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_attend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_attend.BackgroundColor = System.Drawing.Color.White;
            this.grid_attend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_attend.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grid_attend.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_attend.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_attend.ColumnHeadersHeight = 40;
            this.grid_attend.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.grid_attend.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grid_attend.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.grid_attend.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.grid_attend.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.grid_attend.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.grid_attend.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.grid_attend.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.grid_attend.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.grid_attend.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grid_attend.CurrentTheme.Name = null;
            this.grid_attend.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grid_attend.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grid_attend.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.grid_attend.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.grid_attend.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_attend.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid_attend.EnableHeadersVisualStyles = false;
            this.grid_attend.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.grid_attend.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.grid_attend.HeaderBgColor = System.Drawing.Color.Empty;
            this.grid_attend.HeaderForeColor = System.Drawing.Color.White;
            this.grid_attend.Location = new System.Drawing.Point(84, 156);
            this.grid_attend.Name = "grid_attend";
            this.grid_attend.RowHeadersVisible = false;
            this.grid_attend.RowTemplate.Height = 40;
            this.grid_attend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_attend.Size = new System.Drawing.Size(590, 389);
            this.grid_attend.TabIndex = 16;
            this.grid_attend.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // class_attend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1109, 599);
            this.Controls.Add(this.btn_norecord);
            this.Controls.Add(this.bunifuButton2);
            this.Controls.Add(this.dropdown_subl);
            this.Controls.Add(this.txt_datel);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.guna2VScrollBar1);
            this.Controls.Add(this.bunifuButton1);
            this.Controls.Add(this.dropdown_sub);
            this.Controls.Add(this.txt_date);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.grid_attend);
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "class_attend";
            this.Text = "class_attend";
            ((System.ComponentModel.ISupportInitialize)(this.grid_attend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaTextBox txt_code;
        private Guna.UI.WinForms.GunaDateTimePicker txt_date;
        private Bunifu.UI.WinForms.BunifuDropdown dropdown_sub;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton1;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2VScrollBar1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuLabel txt_datel;
        private Bunifu.UI.WinForms.BunifuLabel dropdown_subl;
        private Guna.UI.WinForms.GunaGradientTileButton btn_norecord;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton2;
        private Bunifu.UI.WinForms.BunifuDataGridView grid_attend;
    }
}