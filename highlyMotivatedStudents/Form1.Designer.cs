namespace highlyMotivatedStudents
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.deleteRequestButton = new System.Windows.Forms.Button();
            this.changeRequestButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addRequestButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.students_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year_of_study = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.special_education = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.learning_program = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orientation_of_giftedness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regional_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.all_russian_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.international_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacher_fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.deleteRequestButton);
            this.panel1.Controls.Add(this.changeRequestButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.addRequestButton);
            this.panel1.Location = new System.Drawing.Point(12, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 81);
            this.panel1.TabIndex = 0;
            // 
            // deleteRequestButton
            // 
            this.deleteRequestButton.Location = new System.Drawing.Point(165, 37);
            this.deleteRequestButton.Name = "deleteRequestButton";
            this.deleteRequestButton.Size = new System.Drawing.Size(75, 23);
            this.deleteRequestButton.TabIndex = 3;
            this.deleteRequestButton.Text = "Удалить";
            this.deleteRequestButton.UseVisualStyleBackColor = true;
            this.deleteRequestButton.Click += new System.EventHandler(this.DeleteRequest);
            // 
            // changeRequestButton
            // 
            this.changeRequestButton.Location = new System.Drawing.Point(84, 37);
            this.changeRequestButton.Name = "changeRequestButton";
            this.changeRequestButton.Size = new System.Drawing.Size(75, 23);
            this.changeRequestButton.TabIndex = 2;
            this.changeRequestButton.Text = "Изменить";
            this.changeRequestButton.UseVisualStyleBackColor = true;
            this.changeRequestButton.Click += new System.EventHandler(this.ChangeRequest);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Запросы";
            // 
            // addRequestButton
            // 
            this.addRequestButton.Location = new System.Drawing.Point(3, 37);
            this.addRequestButton.Name = "addRequestButton";
            this.addRequestButton.Size = new System.Drawing.Size(75, 23);
            this.addRequestButton.TabIndex = 0;
            this.addRequestButton.Text = "Добавить";
            this.addRequestButton.UseVisualStyleBackColor = true;
            this.addRequestButton.Click += new System.EventHandler(this.AddRequest);
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.students_id,
            this.full_name,
            this.year_of_study,
            this.special_education,
            this.learning_program,
            this.orientation_of_giftedness,
            this.regional_level,
            this.all_russian_level,
            this.international_level,
            this.teacher_fullname});
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1043, 312);
            this.dataGridView.TabIndex = 3;
            // 
            // students_id
            // 
            this.students_id.HeaderText = "Номер ученика";
            this.students_id.Name = "students_id";
            // 
            // full_name
            // 
            this.full_name.HeaderText = "ФИО ученика";
            this.full_name.Name = "full_name";
            // 
            // year_of_study
            // 
            this.year_of_study.HeaderText = "Год обучения";
            this.year_of_study.Name = "year_of_study";
            // 
            // special_education
            // 
            this.special_education.HeaderText = "Спецобучение в организации";
            this.special_education.Name = "special_education";
            // 
            // learning_program
            // 
            this.learning_program.HeaderText = "Программа обучения";
            this.learning_program.Name = "learning_program";
            // 
            // orientation_of_giftedness
            // 
            this.orientation_of_giftedness.HeaderText = "Интеллектуальная направленость";
            this.orientation_of_giftedness.Name = "orientation_of_giftedness";
            // 
            // regional_level
            // 
            this.regional_level.HeaderText = "Региональные достижения";
            this.regional_level.Name = "regional_level";
            // 
            // all_russian_level
            // 
            this.all_russian_level.HeaderText = "Всероссийские достижения";
            this.all_russian_level.Name = "all_russian_level";
            // 
            // international_level
            // 
            this.international_level.HeaderText = "Международные достижения";
            this.international_level.Name = "international_level";
            // 
            // teacher_fullname
            // 
            this.teacher_fullname.HeaderText = "ФИО учителя, наставника";
            this.teacher_fullname.Name = "teacher_fullname";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(343, 341);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(710, 181);
            this.dataGridView1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 534);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "MainMenu";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MainMenuLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button addRequestButton;
        private System.Windows.Forms.Button changeRequestButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteRequestButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn students_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn year_of_study;
        private System.Windows.Forms.DataGridViewTextBoxColumn special_education;
        private System.Windows.Forms.DataGridViewTextBoxColumn learning_program;
        private System.Windows.Forms.DataGridViewTextBoxColumn orientation_of_giftedness;
        private System.Windows.Forms.DataGridViewTextBoxColumn regional_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn all_russian_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn international_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacher_fullname;
        private System.Windows.Forms.Button button1;
    }
}

