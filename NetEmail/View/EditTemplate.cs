﻿using Backgrounder;
using BusniessLayer;
using DataAccessLayer.DataBase;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class EditTemplate : Form
    {
        private readonly EmailTemplate templateRecord;
        private readonly BackgroundHelper bgHelper;
        private readonly EmailTemplateService emailTemplateService;
        public EditTemplate(EmailTemplate t)
        {
            try
            {
                InitializeComponent();
                emailTemplateService = new EmailTemplateService();
                bgHelper = new BackgroundHelper();

                templateRecord = t;

                string editorUrl = AppDomain.CurrentDomain.BaseDirectory + "Files\\Editor\\Editor.html";
                webBrowser1.Navigate(editorUrl);

                tbxName.Text = templateRecord.TemplateName;
                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                Task.Delay(2000).ContinueWith(t => SetContent());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SetContent()
        {
            bgHelper.Foreground(() =>
            {
                try
                {
                    webBrowser1.Document.InvokeScript("setContent", new String[] { templateRecord.TemplateContent });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });
        }

        public void Test(String message)
        {
            MessageBox.Show(message, "client code");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                emailTemplateService.Save(templateRecord.Id, tbxName.Text, GetElementByClassName("note-editable").InnerHtml);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private HtmlElement GetElementByClassName(string className)
        {
            var elements = webBrowser1.Document.GetElementsByTagName("div");
            foreach (HtmlElement div in elements)
            {
                if (div.GetAttribute("className") == className)
                {
                    return div;
                }
            }

            return null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ?", "Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    emailTemplateService.Delete(templateRecord.Id);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
 
       
    }
}
