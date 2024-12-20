﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MBazaarClassLibrary;
using MBazaarClassLibrary.services;
using MBazaarClassLibrary.models;

namespace MediaBazaar.forms
{
    public partial class AllShifts : Form
    {
        public AllShifts()
        {
            InitializeComponent();
            if (DesktopUtils.loggedEmployee.Role == "Employee manager")
            {
                lblDepartment.Text = "Viewing shifts for: all departments";
            }
            else
            {
                lblDepartment.Text = $"Viewing shifts for {DesktopUtils.loggedEmployee.DepartmentId} ID";
            }
            DateTime dateTime = calShifts.SelectionRange.Start;
            RefreshLV(dateTime);

        }
        private void RefreshLV(DateTime dt)
        {
            string date = dt.ToString(Utils.DbDateFormat);
            try
            {
                List<DetailedWorkday> workdays = WorkdayService.GetWorkdays(date, DesktopUtils.loggedEmployee);
                lvShifts.Items.Clear();
                if (workdays == null)
                {
                    return;
                }
                foreach (DetailedWorkday wd in workdays)
                {
                    string[] row = { wd.Id.ToString(), wd.FirstName, wd.LastName, wd.Role, wd.DepartmentName, wd.Shifts, wd.Missing.ToString() };
                    ListViewItem item = new ListViewItem(row);
                    item.Tag = wd;
                    item.UseItemStyleForSubItems = false;
                    item.SubItems[6].BackColor = wd.Missing ? Color.Tomato : Color.LightGreen;
                    lvShifts.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                VisualHelper.ShowError(ex.Message);
            }
            

        }

        private void calShifts_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dateTime = calShifts.SelectionRange.Start;
            RefreshLV(dateTime);
        }

        private void btnAttended_Click(object sender, EventArgs e)
        {

             try
             {
                string workdayId = lvShifts.SelectedItems[0].Text;
                if (lvShifts.SelectedItems[0].SubItems[6].Text == "False")
                {
                    return;
                }
                if (WorkdayService.MarkAttendance(workdayId, false, DesktopUtils.loggedEmployee))
                {
                    VisualHelper.ShowInfo("Attendance marked");
                   RefreshLV(calShifts.SelectionRange.Start);
                }
             }
             catch (ArgumentOutOfRangeException)
             {
                VisualHelper.ShowError("Nothing selected");
             }
             catch (Exception ex)
             {
                VisualHelper.ShowError(ex.Message);
             }           

        }

        private void btnMissing_Click(object sender, EventArgs e)
        {
            
            try
            {
                string workdayId = lvShifts.SelectedItems[0].Text;
                if (lvShifts.SelectedItems[0].SubItems[6].Text == "True")
                {
                    return;
                }

                if (WorkdayService.MarkAttendance(workdayId, true, DesktopUtils.loggedEmployee))
                {
                    VisualHelper.ShowInfo("Attendance marked");
                    RefreshLV(calShifts.SelectionRange.Start);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                VisualHelper.ShowError("Nothing selected");
            }
            catch (Exception ex)
            {
                VisualHelper.ShowError(ex.Message);
            }
        }
    }
}
