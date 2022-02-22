﻿
namespace MediaBazaar.forms
{
    partial class ManageShifts
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
            this.calShifts = new System.Windows.Forms.MonthCalendar();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cbMorning = new System.Windows.Forms.CheckBox();
            this.cbAfternoon = new System.Windows.Forms.CheckBox();
            this.cbEvening = new System.Windows.Forms.CheckBox();
            this.gbManageShift = new System.Windows.Forms.GroupBox();
            this.btnAddShift = new System.Windows.Forms.Button();
            this.btnRemoveShift = new System.Windows.Forms.Button();
            this.gbManageShift.SuspendLayout();
            this.SuspendLayout();
            // 
            // calShifts
            // 
            this.calShifts.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.calShifts.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.calShifts.Location = new System.Drawing.Point(18, 18);
            this.calShifts.Name = "calShifts";
            this.calShifts.TabIndex = 0;
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmpName.Location = new System.Drawing.Point(307, 28);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(164, 25);
            this.lblEmpName.TabIndex = 1;
            this.lblEmpName.Text = "Name of employee";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Items.AddRange(new object[] {
            "Assigned Shifts: ",
            "Morning, Afternoon"});
            this.listBox1.Location = new System.Drawing.Point(307, 65);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(461, 54);
            this.listBox1.TabIndex = 2;
            // 
            // cbMorning
            // 
            this.cbMorning.AutoSize = true;
            this.cbMorning.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbMorning.Location = new System.Drawing.Point(17, 92);
            this.cbMorning.Name = "cbMorning";
            this.cbMorning.Size = new System.Drawing.Size(102, 29);
            this.cbMorning.TabIndex = 3;
            this.cbMorning.Text = "Morning";
            this.cbMorning.UseVisualStyleBackColor = true;
            // 
            // cbAfternoon
            // 
            this.cbAfternoon.AutoSize = true;
            this.cbAfternoon.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbAfternoon.Location = new System.Drawing.Point(177, 92);
            this.cbAfternoon.Name = "cbAfternoon";
            this.cbAfternoon.Size = new System.Drawing.Size(115, 29);
            this.cbAfternoon.TabIndex = 4;
            this.cbAfternoon.Text = "Afternoon";
            this.cbAfternoon.UseVisualStyleBackColor = true;
            // 
            // cbEvening
            // 
            this.cbEvening.AutoSize = true;
            this.cbEvening.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbEvening.Location = new System.Drawing.Point(348, 92);
            this.cbEvening.Name = "cbEvening";
            this.cbEvening.Size = new System.Drawing.Size(96, 29);
            this.cbEvening.TabIndex = 5;
            this.cbEvening.Text = "Evening";
            this.cbEvening.UseVisualStyleBackColor = true;
            // 
            // gbManageShift
            // 
            this.gbManageShift.Controls.Add(this.btnRemoveShift);
            this.gbManageShift.Controls.Add(this.btnAddShift);
            this.gbManageShift.Controls.Add(this.cbMorning);
            this.gbManageShift.Controls.Add(this.cbEvening);
            this.gbManageShift.Controls.Add(this.cbAfternoon);
            this.gbManageShift.Location = new System.Drawing.Point(307, 150);
            this.gbManageShift.Name = "gbManageShift";
            this.gbManageShift.Size = new System.Drawing.Size(461, 262);
            this.gbManageShift.TabIndex = 6;
            this.gbManageShift.TabStop = false;
            this.gbManageShift.Text = "Manage shift";
            // 
            // btnAddShift
            // 
            this.btnAddShift.Location = new System.Drawing.Point(55, 189);
            this.btnAddShift.Name = "btnAddShift";
            this.btnAddShift.Size = new System.Drawing.Size(138, 38);
            this.btnAddShift.TabIndex = 6;
            this.btnAddShift.Text = "Add shift";
            this.btnAddShift.UseVisualStyleBackColor = true;
            // 
            // btnRemoveShift
            // 
            this.btnRemoveShift.Location = new System.Drawing.Point(252, 189);
            this.btnRemoveShift.Name = "btnRemoveShift";
            this.btnRemoveShift.Size = new System.Drawing.Size(140, 38);
            this.btnRemoveShift.TabIndex = 7;
            this.btnRemoveShift.Text = "Remove shift";
            this.btnRemoveShift.UseVisualStyleBackColor = true;
            // 
            // ManageShifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbManageShift);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblEmpName);
            this.Controls.Add(this.calShifts);
            this.Name = "ManageShifts";
            this.Text = "ManageShifts";
            this.gbManageShift.ResumeLayout(false);
            this.gbManageShift.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calShifts;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox cbMorning;
        private System.Windows.Forms.CheckBox cbAfternoon;
        private System.Windows.Forms.CheckBox cbEvening;
        private System.Windows.Forms.GroupBox gbManageShift;
        private System.Windows.Forms.Button btnRemoveShift;
        private System.Windows.Forms.Button btnAddShift;
    }
}