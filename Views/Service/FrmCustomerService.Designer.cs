namespace Interface
{
    partial class FrmCustomerService
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerService));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblTotalHoursTaken = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cbRows = new System.Windows.Forms.ComboBox();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDescriptionRow = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnArrowRight = new System.Windows.Forms.Button();
            this.btnArrowLeft = new System.Windows.Forms.Button();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.ColEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColDayOffCompleted = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDepartureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumberOfOvertimeHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOvertime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAbatementDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumberOfHoursTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDayOffCompletedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIncrementTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMinutesTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.lkCancel = new System.Windows.Forms.LinkLabel();
            this.cbDefine = new System.Windows.Forms.CheckBox();
            this.rtDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbNumberOfOvertimeHours = new System.Windows.Forms.Label();
            this.dtEntryTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDepartureTime = new System.Windows.Forms.DateTimePicker();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtHoursTaken = new System.Windows.Forms.DateTimePicker();
            this.cbAddHoursTaken = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtAbatementDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(378, 441);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 47);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(130, 18);
            this.lblName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 18);
            this.lblName.TabIndex = 65;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.lblTotalHoursTaken);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Controls.Add(this.dgvHistory);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(539, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(637, 417);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Histórico";
            // 
            // lblTotalHoursTaken
            // 
            this.lblTotalHoursTaken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalHoursTaken.AutoSize = true;
            this.lblTotalHoursTaken.ForeColor = System.Drawing.Color.White;
            this.lblTotalHoursTaken.Location = new System.Drawing.Point(205, 332);
            this.lblTotalHoursTaken.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalHoursTaken.Name = "lblTotalHoursTaken";
            this.lblTotalHoursTaken.Size = new System.Drawing.Size(184, 18);
            this.lblTotalHoursTaken.TabIndex = 85;
            this.lblTotalHoursTaken.Text = "Total de horas em aberto:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 332);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 18);
            this.label2.TabIndex = 84;
            this.label2.Text = "Total de horas em aberto:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbRows);
            this.panel1.Controls.Add(this.cbPage);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblDescriptionRow);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnArrowRight);
            this.panel1.Controls.Add(this.btnArrowLeft);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 365);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 49);
            this.panel1.TabIndex = 70;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(179, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(2, 40);
            this.label8.TabIndex = 17;
            // 
            // cbRows
            // 
            this.cbRows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cbRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRows.ForeColor = System.Drawing.Color.White;
            this.cbRows.FormattingEnabled = true;
            this.cbRows.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25"});
            this.cbRows.Location = new System.Drawing.Point(67, 11);
            this.cbRows.Name = "cbRows";
            this.cbRows.Size = new System.Drawing.Size(94, 26);
            this.cbRows.TabIndex = 16;
            this.cbRows.TabStop = false;
            // 
            // cbPage
            // 
            this.cbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cbPage.DropDownHeight = 150;
            this.cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPage.ForeColor = System.Drawing.Color.White;
            this.cbPage.FormattingEnabled = true;
            this.cbPage.IntegralHeight = false;
            this.cbPage.ItemHeight = 18;
            this.cbPage.Location = new System.Drawing.Point(408, 11);
            this.cbPage.Margin = new System.Windows.Forms.Padding(19, 17, 19, 17);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(97, 26);
            this.cbPage.TabIndex = 15;
            this.cbPage.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(339, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 18);
            this.label9.TabIndex = 14;
            this.label9.Text = "Página";
            // 
            // lblDescriptionRow
            // 
            this.lblDescriptionRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescriptionRow.AutoSize = true;
            this.lblDescriptionRow.Location = new System.Drawing.Point(189, 17);
            this.lblDescriptionRow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescriptionRow.Name = "lblDescriptionRow";
            this.lblDescriptionRow.Size = new System.Drawing.Size(0, 18);
            this.lblDescriptionRow.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 14);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = "Exibir";
            // 
            // btnArrowRight
            // 
            this.btnArrowRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArrowRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArrowRight.Enabled = false;
            this.btnArrowRight.FlatAppearance.BorderSize = 0;
            this.btnArrowRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrowRight.Image = global::Interface.Properties.Resources.right_arrow_grey;
            this.btnArrowRight.Location = new System.Drawing.Point(574, 6);
            this.btnArrowRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnArrowRight.Name = "btnArrowRight";
            this.btnArrowRight.Size = new System.Drawing.Size(38, 35);
            this.btnArrowRight.TabIndex = 1789;
            this.btnArrowRight.TabStop = false;
            this.toolTip.SetToolTip(this.btnArrowRight, "Avançar para a próxima lista - CTRL+Seta Direita");
            this.btnArrowRight.UseVisualStyleBackColor = true;
            this.btnArrowRight.Click += new System.EventHandler(this.BtnArrowRight_Click);
            // 
            // btnArrowLeft
            // 
            this.btnArrowLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArrowLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArrowLeft.Enabled = false;
            this.btnArrowLeft.FlatAppearance.BorderSize = 0;
            this.btnArrowLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrowLeft.Image = global::Interface.Properties.Resources.left_arrow_grey;
            this.btnArrowLeft.Location = new System.Drawing.Point(528, 6);
            this.btnArrowLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnArrowLeft.Name = "btnArrowLeft";
            this.btnArrowLeft.Size = new System.Drawing.Size(38, 35);
            this.btnArrowLeft.TabIndex = 566;
            this.btnArrowLeft.TabStop = false;
            this.toolTip.SetToolTip(this.btnArrowLeft, "Voltar para a lista anterior - CTRL+Seta Esquerda");
            this.btnArrowLeft.UseVisualStyleBackColor = true;
            this.btnArrowLeft.Click += new System.EventHandler(this.BtnArrowLeft_Click);
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeColumns = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            this.dgvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHistory.ColumnHeadersHeight = 40;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColEdit,
            this.ColDelete,
            this.ColDayOffCompleted,
            this.ColId,
            this.ColDate,
            this.ColEntryTime,
            this.ColDepartureTime,
            this.ColNumberOfOvertimeHours,
            this.ColOvertime,
            this.ColDescription,
            this.ColAbatementDate,
            this.ColNumberOfHoursTaken,
            this.ColDayOffCompletedValue,
            this.ColIncrementTime,
            this.ColMinutesTaken});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.Location = new System.Drawing.Point(3, 22);
            this.dgvHistory.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.Size = new System.Drawing.Size(626, 291);
            this.dgvHistory.TabIndex = 0;
            this.dgvHistory.TabStop = false;
            this.dgvHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHistory_CellClick);
            this.dgvHistory.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHistory_CellMouseEnter);
            // 
            // ColEdit
            // 
            this.ColEdit.HeaderText = "Editar";
            this.ColEdit.MinimumWidth = 6;
            this.ColEdit.Name = "ColEdit";
            this.ColEdit.ReadOnly = true;
            this.ColEdit.Width = 125;
            // 
            // ColDelete
            // 
            this.ColDelete.HeaderText = "Excluir";
            this.ColDelete.MinimumWidth = 6;
            this.ColDelete.Name = "ColDelete";
            this.ColDelete.ReadOnly = true;
            this.ColDelete.Width = 125;
            // 
            // ColDayOffCompleted
            // 
            this.ColDayOffCompleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColDayOffCompleted.HeaderText = "Folga concluída";
            this.ColDayOffCompleted.Name = "ColDayOffCompleted";
            this.ColDayOffCompleted.ReadOnly = true;
            this.ColDayOffCompleted.Width = 123;
            // 
            // ColId
            // 
            this.ColId.HeaderText = "ID";
            this.ColId.MinimumWidth = 6;
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Visible = false;
            this.ColId.Width = 125;
            // 
            // ColDate
            // 
            this.ColDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.ColDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColDate.HeaderText = "Data do Serviço";
            this.ColDate.MinimumWidth = 6;
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            this.ColDate.Width = 146;
            // 
            // ColEntryTime
            // 
            this.ColEntryTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColEntryTime.HeaderText = "Hora da Entrada";
            this.ColEntryTime.MinimumWidth = 6;
            this.ColEntryTime.Name = "ColEntryTime";
            this.ColEntryTime.ReadOnly = true;
            this.ColEntryTime.Width = 148;
            // 
            // ColDepartureTime
            // 
            this.ColDepartureTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColDepartureTime.HeaderText = "Hora da saída";
            this.ColDepartureTime.MinimumWidth = 6;
            this.ColDepartureTime.Name = "ColDepartureTime";
            this.ColDepartureTime.ReadOnly = true;
            this.ColDepartureTime.Width = 131;
            // 
            // ColNumberOfOvertimeHours
            // 
            this.ColNumberOfOvertimeHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColNumberOfOvertimeHours.HeaderText = "Quantidade de Minutos";
            this.ColNumberOfOvertimeHours.Name = "ColNumberOfOvertimeHours";
            this.ColNumberOfOvertimeHours.ReadOnly = true;
            this.ColNumberOfOvertimeHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColNumberOfOvertimeHours.Visible = false;
            this.ColNumberOfOvertimeHours.Width = 175;
            // 
            // ColOvertime
            // 
            this.ColOvertime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColOvertime.HeaderText = "Quantidade de horas Extras";
            this.ColOvertime.Name = "ColOvertime";
            this.ColOvertime.ReadOnly = true;
            this.ColOvertime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColOvertime.Width = 208;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColDescription.HeaderText = "Descrição";
            this.ColDescription.MinimumWidth = 6;
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            this.ColDescription.Width = 105;
            // 
            // ColAbatementDate
            // 
            this.ColAbatementDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColAbatementDate.HeaderText = "Data do abatimento";
            this.ColAbatementDate.Name = "ColAbatementDate";
            this.ColAbatementDate.ReadOnly = true;
            this.ColAbatementDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColAbatementDate.Width = 152;
            // 
            // ColNumberOfHoursTaken
            // 
            this.ColNumberOfHoursTaken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColNumberOfHoursTaken.HeaderText = "Quantidade de horas tiradas";
            this.ColNumberOfHoursTaken.Name = "ColNumberOfHoursTaken";
            this.ColNumberOfHoursTaken.ReadOnly = true;
            this.ColNumberOfHoursTaken.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColNumberOfHoursTaken.Width = 212;
            // 
            // ColDayOffCompletedValue
            // 
            this.ColDayOffCompletedValue.HeaderText = "Column1";
            this.ColDayOffCompletedValue.Name = "ColDayOffCompletedValue";
            this.ColDayOffCompletedValue.ReadOnly = true;
            this.ColDayOffCompletedValue.Visible = false;
            // 
            // ColIncrementTime
            // 
            this.ColIncrementTime.HeaderText = "Incrementar hora extras a mais?";
            this.ColIncrementTime.Name = "ColIncrementTime";
            this.ColIncrementTime.ReadOnly = true;
            this.ColIncrementTime.Visible = false;
            // 
            // ColMinutesTaken
            // 
            this.ColMinutesTaken.HeaderText = "MinutesTaken";
            this.ColMinutesTaken.Name = "ColMinutesTaken";
            this.ColMinutesTaken.ReadOnly = true;
            this.ColMinutesTaken.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Enabled = false;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(1018, 443);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(158, 47);
            this.btnPrint.TabIndex = 84;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "Imprimir";
            this.toolTip.SetToolTip(this.btnPrint, "Gerar gráfico - CTRL + G");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lkCancel
            // 
            this.lkCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lkCancel.AutoSize = true;
            this.lkCancel.LinkColor = System.Drawing.Color.White;
            this.lkCancel.Location = new System.Drawing.Point(229, 455);
            this.lkCancel.Name = "lkCancel";
            this.lkCancel.Size = new System.Drawing.Size(125, 18);
            this.lkCancel.TabIndex = 0;
            this.lkCancel.TabStop = true;
            this.lkCancel.Text = "Cancelar Edição";
            this.lkCancel.Visible = false;
            this.lkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LkCancel_LinkClicked);
            // 
            // cbDefine
            // 
            this.cbDefine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDefine.AutoSize = true;
            this.cbDefine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDefine.Location = new System.Drawing.Point(15, 93);
            this.cbDefine.Name = "cbDefine";
            this.cbDefine.Size = new System.Drawing.Size(231, 22);
            this.cbDefine.TabIndex = 3;
            this.cbDefine.Text = "Sábado, domingo ou feriados";
            this.cbDefine.UseVisualStyleBackColor = true;
            this.cbDefine.CheckedChanged += new System.EventHandler(this.cbDefine_CheckedChanged);
            // 
            // rtDescription
            // 
            this.rtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtDescription.Location = new System.Drawing.Point(27, 70);
            this.rtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtDescription.Name = "rtDescription";
            this.rtDescription.Size = new System.Drawing.Size(496, 89);
            this.rtDescription.TabIndex = 0;
            this.rtDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 75;
            this.label3.Text = "Motivo";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lbNumberOfOvertimeHours);
            this.groupBox1.Controls.Add(this.dtEntryTime);
            this.groupBox1.Controls.Add(this.cbDefine);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtDepartureTime);
            this.groupBox1.Controls.Add(this.dtDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(31, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 131);
            this.groupBox1.TabIndex = 81;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Horas Extras";
            // 
            // lbNumberOfOvertimeHours
            // 
            this.lbNumberOfOvertimeHours.AutoSize = true;
            this.lbNumberOfOvertimeHours.Location = new System.Drawing.Point(398, 65);
            this.lbNumberOfOvertimeHours.Name = "lbNumberOfOvertimeHours";
            this.lbNumberOfOvertimeHours.Size = new System.Drawing.Size(63, 18);
            this.lbNumberOfOvertimeHours.TabIndex = 81;
            this.lbNumberOfOvertimeHours.Text = "0h 0min";
            // 
            // dtEntryTime
            // 
            this.dtEntryTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtEntryTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEntryTime.Location = new System.Drawing.Point(140, 59);
            this.dtEntryTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtEntryTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtEntryTime.Name = "dtEntryTime";
            this.dtEntryTime.ShowUpDown = true;
            this.dtEntryTime.Size = new System.Drawing.Size(118, 26);
            this.dtEntryTime.TabIndex = 2;
            this.dtEntryTime.ValueChanged += new System.EventHandler(this.dtEntryTime_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(135, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 18);
            this.label4.TabIndex = 78;
            this.label4.Text = "Hora da entrada";
            // 
            // dtDepartureTime
            // 
            this.dtDepartureTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtDepartureTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtDepartureTime.Location = new System.Drawing.Point(264, 59);
            this.dtDepartureTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDepartureTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDepartureTime.Name = "dtDepartureTime";
            this.dtDepartureTime.ShowUpDown = true;
            this.dtDepartureTime.Size = new System.Drawing.Size(127, 26);
            this.dtDepartureTime.TabIndex = 4;
            this.dtDepartureTime.ValueChanged += new System.EventHandler(this.dtDepartureTime_ValueChanged);
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(17, 59);
            this.dtDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(115, 26);
            this.dtDate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(261, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 18);
            this.label5.TabIndex = 80;
            this.label5.Text = "Hora da saída ";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 18);
            this.label7.TabIndex = 76;
            this.label7.Text = "Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dtHoursTaken);
            this.groupBox2.Controls.Add(this.cbAddHoursTaken);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtAbatementDate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(29, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 131);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Horas Tiradas";
            // 
            // dtHoursTaken
            // 
            this.dtHoursTaken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtHoursTaken.Enabled = false;
            this.dtHoursTaken.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHoursTaken.Location = new System.Drawing.Point(142, 59);
            this.dtHoursTaken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtHoursTaken.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtHoursTaken.Name = "dtHoursTaken";
            this.dtHoursTaken.ShowUpDown = true;
            this.dtHoursTaken.Size = new System.Drawing.Size(83, 26);
            this.dtHoursTaken.TabIndex = 82;
            this.dtHoursTaken.ValueChanged += new System.EventHandler(this.dtHoursTaken_ValueChanged);
            // 
            // cbAddHoursTaken
            // 
            this.cbAddHoursTaken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAddHoursTaken.AutoSize = true;
            this.cbAddHoursTaken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAddHoursTaken.Location = new System.Drawing.Point(19, 95);
            this.cbAddHoursTaken.Name = "cbAddHoursTaken";
            this.cbAddHoursTaken.Size = new System.Drawing.Size(150, 22);
            this.cbAddHoursTaken.TabIndex = 82;
            this.cbAddHoursTaken.Text = "Tirar hora de folga";
            this.cbAddHoursTaken.UseVisualStyleBackColor = true;
            this.cbAddHoursTaken.CheckedChanged += new System.EventHandler(this.CbAddHoursTaken);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(136, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 78;
            this.label1.Text = "Quantidade";
            // 
            // dtAbatementDate
            // 
            this.dtAbatementDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtAbatementDate.Enabled = false;
            this.dtAbatementDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAbatementDate.Location = new System.Drawing.Point(17, 59);
            this.dtAbatementDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtAbatementDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtAbatementDate.Name = "dtAbatementDate";
            this.dtAbatementDate.Size = new System.Drawing.Size(115, 26);
            this.dtAbatementDate.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(12, 29);
            this.label11.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 18);
            this.label11.TabIndex = 76;
            this.label11.Text = "Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 47;
            this.label6.Text = "Funcionário:";
            // 
            // FrmCustomerService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1188, 503);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lkCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtDescription);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1204, 496);
            this.Name = "FrmCustomerService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banco de horas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCustomerService_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCustomerService_KeyDown);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbRows;
        private System.Windows.Forms.ComboBox cbPage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDescriptionRow;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnArrowRight;
        private System.Windows.Forms.Button btnArrowLeft;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.LinkLabel lkCancel;
        private System.Windows.Forms.CheckBox cbDefine;
        private System.Windows.Forms.RichTextBox rtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtEntryTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtDepartureTime;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtAbatementDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbNumberOfOvertimeHours;
        private System.Windows.Forms.CheckBox cbAddHoursTaken;
        private System.Windows.Forms.DateTimePicker dtHoursTaken;
        private System.Windows.Forms.DataGridViewImageColumn ColEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColDelete;
        private System.Windows.Forms.DataGridViewImageColumn ColDayOffCompleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEntryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDepartureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumberOfOvertimeHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOvertime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAbatementDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumberOfHoursTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDayOffCompletedValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIncrementTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMinutesTaken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalHoursTaken;
        private System.Windows.Forms.Button btnPrint;
    }
}