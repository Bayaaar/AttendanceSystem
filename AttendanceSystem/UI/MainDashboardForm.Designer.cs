namespace AttendanceSystem.UI
{
    partial class MainDashboardForm
    {
        private System.ComponentModel.IContainer? components = null;
        private System.Windows.Forms.TableLayoutPanel rootLayout = null!;
        private System.Windows.Forms.Label lblWelcome = null!;
        private System.Windows.Forms.TableLayoutPanel contentLayout = null!;
        private System.Windows.Forms.TableLayoutPanel leftLayout = null!;
        private System.Windows.Forms.GroupBox grpStudent = null!;
        private System.Windows.Forms.TableLayoutPanel studentLayout = null!;
        private System.Windows.Forms.TextBox txtStudentCode = null!;
        private System.Windows.Forms.TextBox txtStudentName = null!;
        private System.Windows.Forms.TextBox txtGroupName = null!;
        private System.Windows.Forms.Button btnAddStudent = null!;
        private System.Windows.Forms.GroupBox grpAttendance = null!;
        private System.Windows.Forms.TableLayoutPanel attendanceLayout = null!;
        private System.Windows.Forms.ComboBox cmbStudent = null!;
        private System.Windows.Forms.DateTimePicker dtpAttendanceDate = null!;
        private System.Windows.Forms.ComboBox cmbStatus = null!;
        private System.Windows.Forms.NumericUpDown numLateMinutes = null!;
        private System.Windows.Forms.CheckBox chkIsExcused = null!;
        private System.Windows.Forms.TextBox txtNote = null!;
        private System.Windows.Forms.FlowLayoutPanel attendanceButtons = null!;
        private System.Windows.Forms.Button btnSave = null!;
        private System.Windows.Forms.Button btnUpdate = null!;
        private System.Windows.Forms.Button btnDelete = null!;
        private System.Windows.Forms.Button btnClear = null!;
        private System.Windows.Forms.TableLayoutPanel rightLayout = null!;
        private System.Windows.Forms.FlowLayoutPanel filterPanel = null!;
        private System.Windows.Forms.TextBox txtSearch = null!;
        private System.Windows.Forms.ComboBox cmbFilterStatus = null!;
        private System.Windows.Forms.Button btnExportCsv = null!;
        private System.Windows.Forms.DataGridView dgvAttendance = null!;
        private System.Windows.Forms.Panel summaryPanel = null!;
        private System.Windows.Forms.Label lblStats = null!;
        private System.Windows.Forms.Panel chartPanel = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            rootLayout = new TableLayoutPanel();
            lblWelcome = new Label();
            contentLayout = new TableLayoutPanel();
            leftLayout = new TableLayoutPanel();
            grpStudent = new GroupBox();
            studentLayout = new TableLayoutPanel();
            txtStudentCode = new TextBox();
            txtStudentName = new TextBox();
            txtGroupName = new TextBox();
            btnAddStudent = new Button();
            grpAttendance = new GroupBox();
            attendanceLayout = new TableLayoutPanel();
            cmbStudent = new ComboBox();
            dtpAttendanceDate = new DateTimePicker();
            cmbStatus = new ComboBox();
            numLateMinutes = new NumericUpDown();
            chkIsExcused = new CheckBox();
            txtNote = new TextBox();
            attendanceButtons = new FlowLayoutPanel();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            rightLayout = new TableLayoutPanel();
            filterPanel = new FlowLayoutPanel();
            txtSearch = new TextBox();
            cmbFilterStatus = new ComboBox();
            btnExportCsv = new Button();
            dgvAttendance = new DataGridView();
            summaryPanel = new Panel();
            lblStats = new Label();
            chartPanel = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            rootLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            leftLayout.SuspendLayout();
            grpStudent.SuspendLayout();
            studentLayout.SuspendLayout();
            grpAttendance.SuspendLayout();
            attendanceLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numLateMinutes).BeginInit();
            attendanceButtons.SuspendLayout();
            rightLayout.SuspendLayout();
            filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            summaryPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(lblWelcome, 0, 0);
            rootLayout.Controls.Add(contentLayout, 0, 1);
            rootLayout.Controls.Add(summaryPanel, 0, 2);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(12);
            rootLayout.RowCount = 3;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            rootLayout.Size = new Size(1320, 820);
            rootLayout.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.Dock = DockStyle.Fill;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(31, 55, 87);
            lblWelcome.Location = new Point(15, 12);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(1290, 48);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Ирцийн хяналтын самбар";
            lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentLayout.Controls.Add(leftLayout, 0, 0);
            contentLayout.Controls.Add(rightLayout, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(15, 63);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Size = new Size(1290, 630);
            contentLayout.TabIndex = 1;
            // 
            // leftLayout
            // 
            leftLayout.ColumnCount = 1;
            leftLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftLayout.Controls.Add(grpStudent, 0, 0);
            leftLayout.Controls.Add(grpAttendance, 0, 1);
            leftLayout.Dock = DockStyle.Fill;
            leftLayout.Location = new Point(3, 3);
            leftLayout.Name = "leftLayout";
            leftLayout.RowCount = 2;
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 196F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftLayout.Size = new Size(314, 624);
            leftLayout.TabIndex = 0;
            // 
            // grpStudent
            // 
            grpStudent.Controls.Add(studentLayout);
            grpStudent.Dock = DockStyle.Fill;
            grpStudent.Location = new Point(3, 3);
            grpStudent.Name = "grpStudent";
            grpStudent.Padding = new Padding(10);
            grpStudent.Size = new Size(308, 190);
            grpStudent.TabIndex = 0;
            grpStudent.TabStop = false;
            grpStudent.Text = "Оюутан нэмэх";
            // 
            // studentLayout
            // 
            studentLayout.ColumnCount = 2;
            studentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
            studentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            studentLayout.Controls.Add(label3, 0, 2);
            studentLayout.Controls.Add(label2, 0, 1);
            studentLayout.Controls.Add(txtStudentCode, 1, 0);
            studentLayout.Controls.Add(txtStudentName, 1, 1);
            studentLayout.Controls.Add(txtGroupName, 1, 2);
            studentLayout.Controls.Add(btnAddStudent, 1, 3);
            studentLayout.Controls.Add(label1, 0, 0);
            studentLayout.Dock = DockStyle.Fill;
            studentLayout.Location = new Point(10, 26);
            studentLayout.Name = "studentLayout";
            studentLayout.RowCount = 4;
            studentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            studentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            studentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            studentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            studentLayout.Size = new Size(288, 154);
            studentLayout.TabIndex = 0;
            // 
            // txtStudentCode
            // 
            txtStudentCode.Dock = DockStyle.Fill;
            txtStudentCode.Location = new Point(95, 3);
            txtStudentCode.Name = "txtStudentCode";
            txtStudentCode.Size = new Size(190, 23);
            txtStudentCode.TabIndex = 1;
            // 
            // txtStudentName
            // 
            txtStudentName.Dock = DockStyle.Fill;
            txtStudentName.Location = new Point(95, 41);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(190, 23);
            txtStudentName.TabIndex = 3;
            // 
            // txtGroupName
            // 
            txtGroupName.Dock = DockStyle.Fill;
            txtGroupName.Location = new Point(95, 79);
            txtGroupName.Name = "txtGroupName";
            txtGroupName.Size = new Size(190, 23);
            txtGroupName.TabIndex = 5;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.FromArgb(36, 104, 173);
            btnAddStudent.Dock = DockStyle.Fill;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(95, 117);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(190, 34);
            btnAddStudent.TabIndex = 6;
            btnAddStudent.Text = "Оюутан нэмэх";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // grpAttendance
            // 
            grpAttendance.Controls.Add(attendanceLayout);
            grpAttendance.Dock = DockStyle.Fill;
            grpAttendance.Location = new Point(3, 199);
            grpAttendance.Name = "grpAttendance";
            grpAttendance.Padding = new Padding(10);
            grpAttendance.Size = new Size(308, 422);
            grpAttendance.TabIndex = 1;
            grpAttendance.TabStop = false;
            grpAttendance.Text = "Ирц бүртгэх / засах";
            // 
            // attendanceLayout
            // 
            attendanceLayout.ColumnCount = 1;
            attendanceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            attendanceLayout.Controls.Add(cmbStudent, 0, 1);
            attendanceLayout.Controls.Add(dtpAttendanceDate, 0, 3);
            attendanceLayout.Controls.Add(cmbStatus, 0, 5);
            attendanceLayout.Controls.Add(numLateMinutes, 0, 7);
            attendanceLayout.Controls.Add(chkIsExcused, 0, 8);
            attendanceLayout.Controls.Add(txtNote, 0, 10);
            attendanceLayout.Controls.Add(attendanceButtons, 0, 11);
            attendanceLayout.Dock = DockStyle.Fill;
            attendanceLayout.Location = new Point(10, 26);
            attendanceLayout.Name = "attendanceLayout";
            attendanceLayout.RowCount = 12;
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            attendanceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            attendanceLayout.Size = new Size(288, 386);
            attendanceLayout.TabIndex = 0;
            // 
            // cmbStudent
            // 
            cmbStudent.Dock = DockStyle.Fill;
            cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudent.Location = new Point(3, 25);
            cmbStudent.Name = "cmbStudent";
            cmbStudent.Size = new Size(282, 23);
            cmbStudent.TabIndex = 1;
            // 
            // dtpAttendanceDate
            // 
            dtpAttendanceDate.Dock = DockStyle.Fill;
            dtpAttendanceDate.Format = DateTimePickerFormat.Short;
            dtpAttendanceDate.Location = new Point(3, 79);
            dtpAttendanceDate.Name = "dtpAttendanceDate";
            dtpAttendanceDate.Size = new Size(282, 23);
            dtpAttendanceDate.TabIndex = 3;
            // 
            // cmbStatus
            // 
            cmbStatus.Dock = DockStyle.Fill;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Location = new Point(3, 133);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(282, 23);
            cmbStatus.TabIndex = 5;
            // 
            // numLateMinutes
            // 
            numLateMinutes.Dock = DockStyle.Left;
            numLateMinutes.Location = new Point(3, 187);
            numLateMinutes.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            numLateMinutes.Name = "numLateMinutes";
            numLateMinutes.Size = new Size(120, 23);
            numLateMinutes.TabIndex = 7;
            // 
            // chkIsExcused
            // 
            chkIsExcused.AutoSize = true;
            chkIsExcused.Location = new Point(3, 219);
            chkIsExcused.Name = "chkIsExcused";
            chkIsExcused.Size = new Size(154, 19);
            chkIsExcused.TabIndex = 8;
            chkIsExcused.Text = "Хүндэтгэх шалтгаантай";
            // 
            // txtNote
            // 
            txtNote.Dock = DockStyle.Fill;
            txtNote.Location = new Point(3, 271);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(282, 30);
            txtNote.TabIndex = 10;
            // 
            // attendanceButtons
            // 
            attendanceButtons.Controls.Add(btnSave);
            attendanceButtons.Controls.Add(btnUpdate);
            attendanceButtons.Controls.Add(btnDelete);
            attendanceButtons.Controls.Add(btnClear);
            attendanceButtons.Dock = DockStyle.Fill;
            attendanceButtons.Location = new Point(3, 307);
            attendanceButtons.Name = "attendanceButtons";
            attendanceButtons.Padding = new Padding(0, 4, 0, 0);
            attendanceButtons.Size = new Size(282, 76);
            attendanceButtons.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(36, 104, 173);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(3, 7);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 32);
            btnSave.TabIndex = 0;
            btnSave.Text = "Бүртгэх";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(137, 7);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(128, 32);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Засах";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.ForeColor = Color.Firebrick;
            btnDelete.Location = new Point(3, 45);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 32);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Устгах";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(137, 45);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(128, 32);
            btnClear.TabIndex = 3;
            btnClear.Text = "Цэвэрлэх";
            btnClear.Click += btnClear_Click;
            // 
            // rightLayout
            // 
            rightLayout.ColumnCount = 1;
            rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightLayout.Controls.Add(filterPanel, 0, 0);
            rightLayout.Controls.Add(dgvAttendance, 0, 1);
            rightLayout.Dock = DockStyle.Fill;
            rightLayout.Location = new Point(323, 3);
            rightLayout.Name = "rightLayout";
            rightLayout.RowCount = 2;
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rightLayout.Size = new Size(964, 624);
            rightLayout.TabIndex = 1;
            // 
            // filterPanel
            // 
            filterPanel.Controls.Add(txtSearch);
            filterPanel.Controls.Add(cmbFilterStatus);
            filterPanel.Controls.Add(btnExportCsv);
            filterPanel.Dock = DockStyle.Fill;
            filterPanel.Location = new Point(3, 3);
            filterPanel.Name = "filterPanel";
            filterPanel.Padding = new Padding(0, 6, 0, 0);
            filterPanel.Size = new Size(958, 46);
            filterPanel.TabIndex = 0;
            filterPanel.WrapContents = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(0, 6);
            txtSearch.Margin = new Padding(0, 0, 8, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Оюутан, код, бүлгээр хайх";
            txtSearch.Size = new Size(280, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.Location = new Point(288, 6);
            cmbFilterStatus.Margin = new Padding(0, 0, 8, 0);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(150, 23);
            cmbFilterStatus.TabIndex = 1;
            cmbFilterStatus.SelectedIndexChanged += cmbFilterStatus_SelectedIndexChanged;
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = Color.FromArgb(55, 139, 99);
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Location = new Point(449, 9);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(130, 32);
            btnExportCsv.TabIndex = 2;
            btnExportCsv.Text = "CSV экспорт";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // dgvAttendance
            // 
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AllowUserToDeleteRows = false;
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.BackgroundColor = Color.White;
            dgvAttendance.ColumnHeadersHeight = 36;
            dgvAttendance.Dock = DockStyle.Fill;
            dgvAttendance.Location = new Point(3, 55);
            dgvAttendance.MultiSelect = false;
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.ReadOnly = true;
            dgvAttendance.RowHeadersVisible = false;
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.Size = new Size(958, 566);
            dgvAttendance.TabIndex = 1;
            dgvAttendance.CellClick += dgvAttendance_CellClick;
            dgvAttendance.CellFormatting += dgvAttendance_CellFormatting;
            // 
            // summaryPanel
            // 
            summaryPanel.Controls.Add(lblStats);
            summaryPanel.Controls.Add(chartPanel);
            summaryPanel.Dock = DockStyle.Fill;
            summaryPanel.Location = new Point(15, 699);
            summaryPanel.Name = "summaryPanel";
            summaryPanel.Size = new Size(1290, 106);
            summaryPanel.TabIndex = 2;
            // 
            // lblStats
            // 
            lblStats.Dock = DockStyle.Left;
            lblStats.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStats.ForeColor = Color.FromArgb(31, 55, 87);
            lblStats.Location = new Point(0, 0);
            lblStats.Name = "lblStats";
            lblStats.Padding = new Padding(8);
            lblStats.Size = new Size(420, 106);
            lblStats.TabIndex = 0;
            lblStats.Text = "Нийт: 0 | Ирсэн: 0 | Хоцорсон: 0 | Тасалсан: 0";
            lblStats.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chartPanel
            // 
            chartPanel.Dock = DockStyle.Fill;
            chartPanel.Location = new Point(0, 0);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(1290, 106);
            chartPanel.TabIndex = 1;
            chartPanel.Paint += chartPanel_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 7;
            label1.Text = "Оюутны код";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 38);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 8;
            label2.Text = "Оюутны нэр";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 76);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 9;
            label3.Text = "Анги";
            // 
            // MainDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 251);
            ClientSize = new Size(1320, 820);
            Controls.Add(rootLayout);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1080, 700);
            Name = "MainDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ирц бүртгэлийн систем";
            rootLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            leftLayout.ResumeLayout(false);
            grpStudent.ResumeLayout(false);
            studentLayout.ResumeLayout(false);
            studentLayout.PerformLayout();
            grpAttendance.ResumeLayout(false);
            attendanceLayout.ResumeLayout(false);
            attendanceLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numLateMinutes).EndInit();
            attendanceButtons.ResumeLayout(false);
            rightLayout.ResumeLayout(false);
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            summaryPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label label3;
        private Label label2;
        private Label label1;
    }
}