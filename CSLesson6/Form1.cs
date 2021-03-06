﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSMoney;

namespace CSLesson6
{
    public partial class Form1 : Form
    {
        private double _balance;

        public Form1()
        {
            InitializeComponent();

            _balance = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MoneyEntry me = new MoneyEntry();

            double income;
            double.TryParse(textBoxAmmount.Text, out income);

            me.Ammount = income;
            me.EntryDate = dtpDate.Value;
            me.Description = textBoxDescription.Text;
            me.Category = textBoxCategory.Text;

            AddEntry(me);
            UpdateBalance();
            ClearFields();
        }

        private void UpdateBalance()
        {
            double balance = 0;

            foreach(DataGridViewRow row in dataGridViewEntries.Rows)
            {
                double income;
                double.TryParse( (row.Cells[1].Value ?? "0").ToString() , out income);

                balance += income;
            }

            textBoxBalance.Text = balance.ToString();
        }

        private void AddEntry(MoneyEntry me)
        {
            dataGridViewEntries.Rows.Add(me.IsDebit ? "Income" : "Outcome",
                me.Ammount,
                me.EntryDate.ToShortDateString(),
                me.Description,
                me.Category);
        }

        private void ClearFields()
        {
            textBoxAmmount.Text = "";
            textBoxCategory.Text = "";
            textBoxDescription.Text = "";
            dtpDate.Value = DateTime.Now;
        }

        private void dataGridViewEntries_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && dataGridViewEntries.Rows.Count > 0)
            {
                double income;
                double.TryParse((dataGridViewEntries[e.ColumnIndex, e.RowIndex].Value ?? "0").ToString(), out income);

                dataGridViewEntries[0, e.RowIndex].Value = (income > 0) ? "Income" : "Outcome" ;

                UpdateBalance();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello! Have a look at your finances.");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show(string.Format("Your Balance is {0}", textBoxBalance.Text));
        }
    }
}
