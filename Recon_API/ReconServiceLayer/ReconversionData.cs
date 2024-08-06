using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using ReconModels;
using System.Data;
using System;
using System.IO;
using static ReconModels.ReconVersionmodel;
using Font = iTextSharp.text.Font;
using DocumentFormat.OpenXml.Presentation;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using SixLabors.Fonts;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Bibliography;

namespace ReconDataLayer
{
    public class ReconversionData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        DBManager dbManager = new DBManager("ConnectionString");
        List<IDbDataParameter>? parameters;
        public DataSet ReconVersionfetchdata(ReconVersionmodellist Objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_fetch_reconversion", CommandType.StoredProcedure, parameters.ToArray());
                if (ds.Tables.Count >= 4)
                {
                    ds.Tables[0].TableName = "versionlist";
                    ds.Tables[1].TableName = "Reconversion";
                    ds.Tables[2].TableName = "theme";
                    ds.Tables[3].TableName = "preprocess";
                }
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_fetch_reconversion" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message, "pr_fetch_reconversion", headerval.user_code, constring);
                return ds;
            }
        }

        public DataSet ReconVersionhistorydata(ReconVersionhsitorylist Objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_version_code", Objmodel.in_version_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_fetch_reconversionhistory", CommandType.StoredProcedure, parameters.ToArray());
                if (ds.Tables.Count >= 3)
                {
                    ds.Tables[0].TableName = "versionlist";
                    ds.Tables[1].TableName = "theme";
                    ds.Tables[2].TableName = "preprocess";
                }
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_fetch_reconversionhistory" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message, "pr_fetch_reconversionhistory", headerval.user_code, constring);
                return ds;
            }
        }

        public DataTable ReconVersionsavedata(ReconVersionmodelsave Objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_rule_code", Objmodel.in_rule_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_theme_code", Objmodel.in_theme_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_preprocess_code", Objmodel.in_preprocess_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_reconrule_version", Objmodel.in_reconrule_version, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_set_reconrule_version", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_set_reconrule_version" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message, "pr_set_reconrule_version", headerval.user_code, constring);
                return result;
            }
        }

        private PdfPTable PdfdynamicTableGenration(DataTable dt)
        {
            PdfPTable table = new PdfPTable(dt.Columns.Count) { WidthPercentage = 100 };
            BaseColor borderColor = new BaseColor(217, 222, 227); // Gray color
            foreach (DataColumn column in dt.Columns)
            {
                if (column.ColumnName == "-")
                {
                    column.ColumnName = " ";
                }
                else if (column.ColumnName == "--")
                {
                    column.ColumnName = "   ";
                }
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, BaseColor.WHITE);
                table.AddCell(CreateHeaderCell(column.ColumnName, headerFont, new BaseColor(70, 130, 180)));
            }

            // Add rows
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    Font dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);

                    PdfPCell cell = new PdfPCell(new Phrase(row[column].ToString(), dataFont))
                    {
                        BorderColor = borderColor
                    };
                    if (column.DataType == typeof(string))
                    {
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    }
                    else if (column.DataType == typeof(int) || column.DataType == typeof(float) || column.DataType == typeof(double) || column.DataType == typeof(decimal))
                    {
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    }

                    // Vertical alignment
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                    table.AddCell(cell);
                }
            }

            return table;
        }
        private PdfPCell CreateLabelCell(string labelText, bool isRequired)
        {
            Font font = new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL);
            Chunk labelChunk = new Chunk(labelText, font);
            Phrase labelPhrase = new Phrase(labelChunk);
            PdfPCell labelCell = new PdfPCell(labelPhrase) { Border = PdfPCell.NO_BORDER };
            return labelCell;
        }
        private PdfPCell CreateHeaderCell(string text, Font font, BaseColor backgroundColor)
        {
            PdfPCell headerCell = new PdfPCell(new Phrase(text, font))
            {
                BackgroundColor = backgroundColor,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Padding = 5,
                BorderColor = new BaseColor(217, 222, 227)
            };
            return headerCell;
        }
        private Paragraph CreateMainTitle(string title)
        {
            iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, iTextSharp.text.Font.BOLD);
            Paragraph prgHeading = new Paragraph("", boldFont)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingBefore = 10f, // Set desired space before the title
                SpacingAfter = 0 // Set desired space after the title
            };
            Chunk headingChunk = new Chunk(title.ToUpper(), boldFont);
            headingChunk.SetUnderline(0.5f, -1.5f);
            prgHeading.Add(headingChunk);
            return prgHeading;
        }
        private Paragraph CreateMainTitle1(string title)
        {
            iTextSharp.text.Font boldFont = new iTextSharp.text.Font();
            boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10); //, iTextSharp.text.Font.BOLD);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            Chunk headingChunk = new Chunk(title.ToUpper(), boldFont);
            headingChunk.SetUnderline(0.5f, -1.5f);
            prgHeading.Add(headingChunk);
            Paragraph spaceAfter = new Paragraph(" ", boldFont);
            spaceAfter.SpacingBefore = 4f;
            prgHeading.Add(spaceAfter);
            return prgHeading;
        }
        private Paragraph CreateTitle(string title, BaseColor dynamicColor)
        {
            // Create a bold font with white color
            iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);

            // Create a paragraph for the heading
            Paragraph prgHeading = new Paragraph();
            string camelCaseTitle = ToInitialCaps(title);
            prgHeading.Alignment = Element.ALIGN_LEFT;

            // Create a chunk with the heading text and bold font
            Chunk headingChunk = new Chunk(camelCaseTitle, boldFont);
            //headingChunk.SetUnderline(0.5f, -1.5f);

            // Create a custom color for mustard yellow rgb(235,147,22)
            // BaseColor mustardYellow = new BaseColor(235, 147, 22); 

            // Create a cell with the heading chunk to set the background color
            PdfPCell cell = new PdfPCell(new Phrase(headingChunk));
            cell.BackgroundColor = dynamicColor;
            cell.Border = Rectangle.NO_BORDER;

            // Create a table with one column to hold the cell
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            table.AddCell(cell);

            // Add the table to the paragraph
            prgHeading.Add(table);

            // Add space after the heading
            Paragraph spaceAfter = new Paragraph(" ", boldFont);
            spaceAfter.SpacingBefore = 1f;
            prgHeading.Add(spaceAfter);

            return prgHeading;
        }
        public static string ToInitialCaps(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return title;
            }

            TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
            return textInfo.ToTitleCase(title.ToLowerInvariant());
        }
        public byte[] ReconReportVersionhistoryData(ReconReportVersionhistoryModel objReconReportVersionhistory, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                float fh = 8f;
                BaseColor mustardYellow = new BaseColor(235, 147, 22);
                BaseColor grassGreen = new BaseColor(0, 102, 0);
                BaseColor reconPurpple = new BaseColor(135, 46, 123);
                BaseColor ironbrown = new BaseColor(153, 0, 0);
                string logoPath = "D:\\user\\hema\\Recon\\ReconWeb\\ReconWeb\\Recon\\Recon_proto\\wwwroot\\Assets\\images\\footerlogo_new.png";
                DBManager dbManager = new DBManager(constring);
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objReconReportVersionhistory.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_version_code", objReconReportVersionhistory.in_version_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_report_reconversionhistory", CommandType.StoredProcedure, parameters.ToArray());
                if (ds.Tables.Count >= 3)
                {
                    ds.Tables[0].TableName = "Recondetail";
                    ds.Tables[1].TableName = "Rulelist";
                    ds.Tables[2].TableName = "themelist";
                    ds.Tables[3].TableName = "preprocesslist";
                }
                MemoryStream ms = new MemoryStream();
                Rectangle rec = new Rectangle(PageSize.A4);
                Dictionary<string, int> tocEntries = new Dictionary<string, int>();
                using (Document document = new Document(rec, 30f, 30f, 30f, 30f))
                {
                    // Dynamic Table data
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();
                    DataTable dt4 = new DataTable();
                    dt1 = ds.Tables["Recondetail"];
                    dt2 = ds.Tables["Rulelist"];
                    dt3 = ds.Tables["themelist"];
                    dt4 = ds.Tables["preprocesslist"];
                    // Track headings and their page numbers

                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
					writer.PageEvent = new PdfFooter(logoPath); 
					document.Open();
                    BaseColor borderColor = new BaseColor(169, 169, 169);

                    /* Header Start */

                    // Input field
                    PdfPTable mainTable = new PdfPTable(3) { WidthPercentage = 100 };
                    mainTable.SetWidths(new float[] { 10f, 5f, 10f });

                    // Title
                    document.Add(CreateMainTitle1("Recon Version History - " + objReconReportVersionhistory.in_version_code));
                    tocEntries.Add("Recon Version History - " + objReconReportVersionhistory.in_version_code, writer.PageNumber);

                    // Recon Code Column
                    PdfPTable reconCodeTable = new PdfPTable(1);
                    reconCodeTable.AddCell(CreateLabelCell("Recon Code : " + dt1.Rows[0]["Recon Code"], true));

                    PdfPCell reconCodeCell = new PdfPCell(reconCodeTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                        BorderColor = borderColor
                    };
                    mainTable.AddCell(reconCodeCell);
                    // Add an empty blank space
                    mainTable.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });
                    // Recon Name Column
                    PdfPTable reconNameTable = new PdfPTable(1);
                    reconNameTable.AddCell(CreateLabelCell("Recon Name : " + dt1.Rows[0]["Recon Name"], true));
                    PdfPCell reconNameCell = new PdfPCell(reconNameTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                        BorderColor = borderColor
                    };
                    mainTable.AddCell(reconNameCell);
                    // Empty Line
                    PdfPCell blankCell = new PdfPCell(new Phrase(" "))
                    {
                        Colspan = 3,
                        FixedHeight = 8f, // Adjust height as needed
                        Border = PdfPCell.NO_BORDER
                    };
                    mainTable.AddCell(blankCell);
                    // History Version Column
                    PdfPTable historyVersionTable = new PdfPTable(1);
                    historyVersionTable.AddCell(CreateLabelCell("History Version : " + objReconReportVersionhistory.in_version_code, true));
                    PdfPCell historyVersionCell = new PdfPCell(historyVersionTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                        BorderColor = borderColor
                    };
                    mainTable.AddCell(historyVersionCell);
                    // Add an empty blank space
                    mainTable.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });
                    // Recon Type Column
                    PdfPTable reconTypeTable = new PdfPTable(1);
                    reconTypeTable.AddCell(CreateLabelCell("Recon Type : " + dt1.Rows[0]["Recon Type"], true));
                    PdfPCell reconTypeCell = new PdfPCell(reconTypeTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                        BorderColor = borderColor
                    };
                    mainTable.AddCell(reconTypeCell);
                    // Empty Line
                    PdfPCell blankCell1 = new PdfPCell(new Phrase(" "))
                    {
                        Colspan = 3,
                        FixedHeight = fh,
                        Border = PdfPCell.NO_BORDER
                    };
                    mainTable.AddCell(blankCell1);
                    // Period From Column
                    PdfPTable periodFromTable = new PdfPTable(1);
                    periodFromTable.AddCell(CreateLabelCell("Active From : " + dt1.Rows[0]["Period From"], true));
                    PdfPCell periodFromTypeCell = new PdfPCell(periodFromTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                        BorderColor = borderColor
                    };
                    mainTable.AddCell(periodFromTypeCell);
                    // Add an empty blank space
                    mainTable.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });
                    // Period To Column
                    if (dt1.Rows[0]["until_active_flag"].ToString() == "YES")
                    {
                        PdfPTable periodToTable = new PdfPTable(1);
                        periodToTable.AddCell(CreateLabelCell("Active To : " + "Until Inactive", true));
                        PdfPCell periodToTypeCell = new PdfPCell(periodToTable)
                        {
                            Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                            BackgroundColor = new BaseColor(230, 230, 250),
                            BorderColor = borderColor
                        };
                        mainTable.AddCell(periodToTypeCell);
                    }
                    else
                    {
                        PdfPTable periodToTable = new PdfPTable(1);
                        periodToTable.AddCell(CreateLabelCell("Active To : " + dt1.Rows[0]["Period To"], true));

                        PdfPCell periodToTypeCell = new PdfPCell(periodToTable)
                        {
                            Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                            BackgroundColor = new BaseColor(230, 230, 250),
                            BorderColor = borderColor
                        };
                        mainTable.AddCell(periodToTypeCell);
                    }
                    // Adding Blank Space
                    PdfPCell blankCell2 = new PdfPCell(new Phrase(" "))
                    {
                        Colspan = 3,
                        FixedHeight = fh, // Adjust height as needed
                        Border = PdfPCell.NO_BORDER
                    };
                    mainTable.AddCell(blankCell2);
                    document.Add(mainTable);
                    /* Header Ends */

                    // List Table for Rule ,Theme and PreProcess

                    if (dt4.Rows.Count > 0)
                    {
                        string mainTitle = "PreProcess List";
                        document.Add(CreateTitle("PreProcess List", mustardYellow));
                        tocEntries.Add(mainTitle, writer.PageNumber);
                        document.Add(PdfdynamicTableGenration(dt4));
                        PdfPTable spacerTableAfter = new PdfPTable(1);
                        PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
                        {
                            FixedHeight = fh,
                            Border = PdfPCell.NO_BORDER
                        };
                        spacerTableAfter.AddCell(spacerCellAfter);
                        document.Add(spacerTableAfter);
                    }
                    if (dt2.Rows.Count > 0)
                    {
                        string mainTitle = "Rule List";
                        document.Add(CreateTitle("Rule List", mustardYellow));
                        tocEntries.Add(mainTitle, writer.PageNumber);
                        document.Add(PdfdynamicTableGenration(dt2));
                        PdfPTable spacerTableAfter = new PdfPTable(1);
                        PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
                        {
                            FixedHeight = fh,
                            Border = PdfPCell.NO_BORDER
                        };
                        spacerTableAfter.AddCell(spacerCellAfter);
                        document.Add(spacerTableAfter);
                    }
                    if (dt3.Rows.Count > 0)
                    {
                        string mainTitle = "Theme List";
                        document.Add(CreateTitle("Theme List", mustardYellow));
                        tocEntries.Add(mainTitle, writer.PageNumber);
                        document.Add(PdfdynamicTableGenration(dt3));
                        PdfPTable spacerTableAfter = new PdfPTable(1);
                        PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
                        {
                            FixedHeight = fh,
                            Border = PdfPCell.NO_BORDER
                        };
                        spacerTableAfter.AddCell(spacerCellAfter);
                        document.Add(spacerTableAfter);
                    }
                    document.NewPage();
                    /* Table Starts Rule */
                    if (dt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            PdfPTable mainTable1 = new PdfPTable(3) { WidthPercentage = 100 };
                            mainTable1.SetWidths(new float[] { 10f, 10f, 10f });
                            parameters = new List<IDbDataParameter>();
                            parameters.Add(dbManager.CreateParameter("in_rule_code", Convert.ToString(dt2.Rows[i]["Rule Code"]), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_recon_code", Convert.ToString(objReconReportVersionhistory.in_recon_code), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_rule_version", Convert.ToString(objReconReportVersionhistory.in_version_code), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                            ds = dbManager.execStoredProcedure("pr_report_rulecondition", CommandType.StoredProcedure, parameters.ToArray());
                            // Rule Code Column
                            string maintitle = i + 1 + ". " + "Rule Details";
                            document.Add(CreateTitle(i + 1 + ". " + "Rule Details" + " - " + dt2.Rows[i]["Rule Order"], grassGreen));
                            tocEntries.Add(maintitle, writer.PageNumber);
                            PdfPTable ruleCodeTable = new PdfPTable(1);
                            ruleCodeTable.AddCell(CreateLabelCell("Rule Code : " + dt2.Rows[i]["Rule Code"], true));
                            PdfPCell ruleCodeCell = new PdfPCell(ruleCodeTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable1.AddCell(ruleCodeCell);
                            // Rule Name column
                            PdfPTable ruleNameTable = new PdfPTable(1);
                            ruleNameTable.AddCell(CreateLabelCell("Rule Name : " + dt2.Rows[i]["Rule Name"], true));
                            PdfPCell ruleNameCell = new PdfPCell(ruleNameTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable1.AddCell(ruleNameCell);

                            //Rule Applied Column
                            PdfPTable ruleAppliedTable = new PdfPTable(1);
                            ruleAppliedTable.AddCell(CreateLabelCell("Rule Applied On : " + dt2.Rows[i]["Rule Applied On"], true));
                            PdfPCell ruleAppliedCell = new PdfPCell(ruleAppliedTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable1.AddCell(ruleAppliedCell);
                            PdfPCell blankCell3 = new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 3,
                                FixedHeight = fh,
                                Border = PdfPCell.NO_BORDER
                            };
                            mainTable1.AddCell(blankCell3);
                            // Source Dataset Column
                            PdfPTable ruleSourceTable = new PdfPTable(1);
                            ruleSourceTable.AddCell(CreateLabelCell("Source Dataset : " + dt2.Rows[i]["Source Dataset"], true));
                            PdfPCell ruleSourceCell = new PdfPCell(ruleSourceTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable1.AddCell(ruleSourceCell);
                            // Source Account Mode Column
                            PdfPTable ruleSourceModeTable = new PdfPTable(1);
                            ruleSourceModeTable.AddCell(CreateLabelCell("Source Acc Mode : " + dt2.Rows[i]["Source Acc Mode"], true));
                            PdfPCell ruleSourceModeCell = new PdfPCell(ruleSourceModeTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable1.AddCell(ruleSourceModeCell);
                            //Comparison Dataset
                            PdfPTable ruleComparisonTable = new PdfPTable(1);
                            ruleComparisonTable.AddCell(CreateLabelCell("Comparison Dataset : " + dt2.Rows[i]["Comparison Dataset"], true));
                            PdfPCell ruleComparisonCell = new PdfPCell(ruleComparisonTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable1.AddCell(ruleComparisonCell);
                            PdfPCell blankCell5 = new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 3,
                                FixedHeight = fh,
                                Border = PdfPCell.NO_BORDER
                            };
                            mainTable1.AddCell(blankCell5);
                            //Comparison Account Mode Dataset
                            PdfPTable ruleComparisonModeTable = new PdfPTable(1);
                            ruleComparisonModeTable.AddCell(CreateLabelCell("Comparison Acc Mode : " + dt2.Rows[i]["Comparison Acc Mode"], true));
                            PdfPCell ruleComparisonModeCell = new PdfPCell(ruleComparisonModeTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable1.AddCell(ruleComparisonModeCell);
                            // Group Flag Column
                            PdfPTable ruleGroupTable = new PdfPTable(1);
                            ruleGroupTable.AddCell(CreateLabelCell("Rule Group : " + dt2.Rows[i]["Group Flag"], true));
                            PdfPCell ruleGroupCell = new PdfPCell(ruleGroupTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable1.AddCell(ruleGroupCell);
                            // Rule Order Column
                            PdfPTable ruleOrderTable = new PdfPTable(1);
                            ruleOrderTable.AddCell(CreateLabelCell("Rule Order : " + dt2.Rows[i]["Rule Order"], true));
                            PdfPCell ruleOrderCell = new PdfPCell(ruleOrderTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable1.AddCell(ruleOrderCell);
                            PdfPCell blankCell4 = new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 3,
                                FixedHeight = fh,
                                Border = PdfPCell.NO_BORDER
                            };
                            mainTable1.AddCell(blankCell4);
                            document.Add(mainTable1);
                            //Table and space between                           
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                document.Add(CreateTitle("Rule Condition", mustardYellow));
                                // tocEntries.Add("Rule Conditionnnn", writer.PageNumber);
                                document.Add(PdfdynamicTableGenration(ds.Tables[0]));
                                PdfPTable spacerTableAfter = new PdfPTable(1);
                                PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = fh,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter.AddCell(spacerCellAfter);
                                document.Add(spacerTableAfter);
                            }
                            //Table and space between
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                string mainTitle = "Rule Source Filter";
                                document.Add(CreateTitle("Rule Source Filter", mustardYellow));
                                tocEntries.Add(mainTitle, writer.PageNumber);
                                document.Add(PdfdynamicTableGenration(ds.Tables[1]));
                                PdfPTable spacerTableAfter1 = new PdfPTable(1);
                                PdfPCell spacerCellAfter1 = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = fh,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter1.AddCell(spacerCellAfter1);
                                document.Add(spacerTableAfter1);
                            }
                            //Table and space between
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                string mainTitle = "Rule Comparision Filter";
                                document.Add(CreateTitle("Rule Comparision Filter", mustardYellow));
                                tocEntries.Add(mainTitle, writer.PageNumber);
                                document.Add(PdfdynamicTableGenration(ds.Tables[2]));
                                PdfPTable spacerTableAfter2 = new PdfPTable(1);
                                PdfPCell spacerCellAfter2 = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = fh,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter2.AddCell(spacerCellAfter2);
                                document.Add(spacerTableAfter2);
                            }
                            //Table and space between
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                string mainTitle = "Rule Group Filter";
                                document.Add(CreateTitle("Rule Group Filter", mustardYellow));
                                tocEntries.Add(mainTitle, writer.PageNumber);
                                document.Add(PdfdynamicTableGenration(ds.Tables[3]));
                                PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = fh,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter3.AddCell(spacerCellAfter3);
                                document.Add(spacerTableAfter3);
                            }
                        }
                    }
                    /* Table Ends Rule */

                    /* Table Starts Theme */
                    document.NewPage();
                    if (dt3.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt3.Rows.Count; i++)
                        {
                            PdfPTable mainTable2 = new PdfPTable(3) { WidthPercentage = 100 }; // PdfPTable(3) Number of columns
                            mainTable2.SetWidths(new float[] { 10f, 10f, 10f }); // set width for the three column
                            parameters = new List<IDbDataParameter>();
                            parameters.Add(dbManager.CreateParameter("in_theme_code", Convert.ToString(dt3.Rows[i]["Theme Code"]), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_recon_code", Convert.ToString(objReconReportVersionhistory.in_recon_code), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_theme_version", Convert.ToString(objReconReportVersionhistory.in_version_code), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                            ds = dbManager.execStoredProcedure("pr_report_themedetails", CommandType.StoredProcedure, parameters.ToArray());
                            document.Add(CreateTitle(i + 1 + ". " + "Theme Details", reconPurpple));
                            string mainTitle = i + 1 + "." + "Theme Details";
                            tocEntries.Add(mainTitle, writer.PageNumber);
                            //Theme Code
                            PdfPTable themeCodeTable = new PdfPTable(1);
                            themeCodeTable.AddCell(CreateLabelCell("Theme Code : " + dt3.Rows[i]["Theme Code"], true));
                            PdfPCell themeCodeCell = new PdfPCell(themeCodeTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable2.AddCell(themeCodeCell);
                            // Theme Name Column
                            PdfPTable themeNameTable = new PdfPTable(1);
                            themeNameTable.AddCell(CreateLabelCell("Theme Name : " + dt3.Rows[i]["Theme Name"], true));
                            PdfPCell themeNameCell = new PdfPCell(themeNameTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable2.AddCell(themeNameCell);
                            //Theme Order
                            PdfPTable themeOrderTable = new PdfPTable(1);
                            themeOrderTable.AddCell(CreateLabelCell("Theme Order : " + dt3.Rows[i]["Theme Order"], true));
                            PdfPCell themeOrderCell = new PdfPCell(themeOrderTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable2.AddCell(themeOrderCell);
                            PdfPCell blankCell3 = new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 3,
                                FixedHeight = fh,
                                Border = PdfPCell.NO_BORDER
                            };
                            mainTable2.AddCell(blankCell3);
                            // Hold Flag Column
                            PdfPTable themeholdTable = new PdfPTable(1);
                            themeholdTable.AddCell(CreateLabelCell("Hold Flag : " + dt3.Rows[i]["Hold Flag"], true));
                            PdfPCell themeHoldCell = new PdfPCell(themeholdTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable2.AddCell(themeHoldCell);
                            // Theme Type Column
                            PdfPTable themeTypeTable = new PdfPTable(1);
                            themeTypeTable.AddCell(CreateLabelCell("Theme Type: " + dt3.Rows[i]["Theme Type"], true));

                            PdfPCell themeTypeCell = new PdfPCell(themeTypeTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable2.AddCell(themeTypeCell);
                            // Add Empty Cell for Space
                            PdfPCell blankCellTheme = new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 3,
                                FixedHeight = fh,
                                Border = PdfPCell.NO_BORDER
                            };
                            mainTable2.AddCell(blankCellTheme);
                            PdfPCell blankCell5 = new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 3,
                                FixedHeight = fh,
                                Border = PdfPCell.NO_BORDER
                            };
                            mainTable2.AddCell(blankCell5);
                            document.Add(mainTable2);
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                string mainTitle1 = "Theme Condition";
                                document.Add(CreateTitle("Theme Condition", mustardYellow));
                                tocEntries.Add(mainTitle1, writer.PageNumber);
                                document.Add(PdfdynamicTableGenration(ds.Tables[1]));
                                PdfPTable spacerTableAfter = new PdfPTable(1);
                                PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = fh,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter.AddCell(spacerCellAfter);
                                document.Add(spacerTableAfter);
                            }
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                string mainTitle1 = "Theme Source Identifier";
                                document.Add(CreateTitle("Theme Source Identifier", mustardYellow));
                                tocEntries.Add(mainTitle1, writer.PageNumber);
                                document.Add(PdfdynamicTableGenration(ds.Tables[2]));
                                PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = fh,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter3.AddCell(spacerCellAfter3);
                                document.Add(spacerTableAfter3);
                            }
                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                string maintitle = "Theme Comparision Identifier";
                                document.Add(CreateTitle("Theme Comparision Identifier", mustardYellow));
                                tocEntries.Add(maintitle, writer.PageNumber);
                                document.Add(PdfdynamicTableGenration(ds.Tables[3]));
                                PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = fh,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter3.AddCell(spacerCellAfter3);
                                document.Add(spacerTableAfter3);
                            }
                        }
                    }
                    /* Table Ends Theme */
                    document.NewPage();
                    /* Table Starts PreProcess */
                    if (dt4.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt4.Rows.Count; i++)
                        {
                            PdfPTable mainTable3 = new PdfPTable(3) { WidthPercentage = 100 }; // PdfPTable(3) Number of columns
                            mainTable3.SetWidths(new float[] { 10f, 10f, 10f }); // set width for the three column
                            parameters = new List<IDbDataParameter>();
                            parameters.Add(dbManager.CreateParameter("in_preprocess_code", Convert.ToString(dt4.Rows[i]["Preprocess Code"]), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_recon_code", Convert.ToString(objReconReportVersionhistory.in_recon_code), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_version_code", Convert.ToString(objReconReportVersionhistory.in_version_code), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                            ds = dbManager.execStoredProcedure("pr_report_preprocessdetails", CommandType.StoredProcedure, parameters.ToArray());
                            document.Add(CreateTitle(i + 1 + ". " + "Preprocess Details", ironbrown));
                            string maintitle = i + 1 + ". " + "Preprocess Details";
                            tocEntries.Add(maintitle, writer.PageNumber);

                            //PreProcess Code
                            PdfPTable preprocessCodeTable = new PdfPTable(1);
                            preprocessCodeTable.AddCell(CreateLabelCell("PreProcess Code : " + dt4.Rows[i]["Preprocess Code"], true));
                            PdfPCell preprocessCodeCell = new PdfPCell(preprocessCodeTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable3.AddCell(preprocessCodeCell);
                            //PreProcess Name
                            PdfPTable preprocessNameTable = new PdfPTable(1);
                            preprocessNameTable.AddCell(CreateLabelCell("PreProcess Name : " + dt4.Rows[i]["Preprocess Name"], true));
                            PdfPCell preprocessNameCell = new PdfPCell(preprocessNameTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable3.AddCell(preprocessNameCell);
                            //PreProcess Method
                            PdfPTable preprocessMethodTable = new PdfPTable(1);
                            preprocessMethodTable.AddCell(CreateLabelCell("PreProcess Method : " + dt4.Rows[i]["Process Method Desc"], true));
                            PdfPCell preprocessMethodCell = new PdfPCell(preprocessMethodTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable3.AddCell(preprocessMethodCell);
                            PdfPCell blankCell4 = new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 3,
                                FixedHeight = fh,
                                Border = PdfPCell.NO_BORDER
                            };
                            mainTable3.AddCell(blankCell4);
                            //Hold Flag
                            PdfPTable preprocessHoldTable = new PdfPTable(1);
                            preprocessHoldTable.AddCell(CreateLabelCell("Hold Flag : " + dt4.Rows[i]["Hold Flag"], true));
                            PdfPCell preprocessHoldCell = new PdfPCell(preprocessHoldTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable3.AddCell(preprocessHoldCell);
                            //Preprocess Order
                            PdfPTable preprocessOrderTable = new PdfPTable(1);
                            preprocessOrderTable.AddCell(CreateLabelCell("Preprocess Order : " + dt4.Rows[i]["Preprocess Order"], true));
                            PdfPCell preprocessOrderCell = new PdfPCell(preprocessOrderTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),
                                BorderColor = borderColor
                            };
                            mainTable3.AddCell(preprocessOrderCell);
                            // Add an empty blank space
                            PdfPCell blankCellPreProcess = new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 3,
                                FixedHeight = fh,
                                Border = PdfPCell.NO_BORDER
                            };
                            PdfPCell blankCell6 = new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 3,
                                FixedHeight = fh,
                                Border = PdfPCell.NO_BORDER
                            };
                            mainTable3.AddCell(blankCell6);
                            mainTable3.AddCell(blankCellPreProcess);
                            document.Add(mainTable3);
                            // Preprocess Filter
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                document.Add(CreateTitle("PreProcess Filter", mustardYellow));
                                document.Add(PdfdynamicTableGenration(ds.Tables[1]));
                                PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = fh,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter3.AddCell(spacerCellAfter3);
                                document.Add(spacerTableAfter3);
                            }
                            // Query
                            if (dt4.Rows[i]["Process Method"].ToString() == "QCD_QUERY")
                            {
                                if (ds.Tables[5].Rows.Count > 0)
                                {
                                    document.Add(CreateTitle("Query", mustardYellow));
                                    document.Add(PdfdynamicTableGenration(ds.Tables[5]));
                                    PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                    PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                    {
                                        FixedHeight = fh,
                                        Border = PdfPCell.NO_BORDER
                                    };
                                    spacerTableAfter3.AddCell(spacerCellAfter3);
                                    document.Add(spacerTableAfter3);
                                }
                            }
                            // Lookup consition Header
                            else if (dt4.Rows[i]["Process Method"].ToString() == "QCD_LOOKUP")
                            {
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    document.Add(CreateTitle("Lookup Condition Header", mustardYellow));
                                    document.Add(PdfdynamicTableGenration(ds.Tables[3]));
                                    PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                    PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                    {
                                        FixedHeight = fh,
                                        Border = PdfPCell.NO_BORDER
                                    };
                                    spacerTableAfter3.AddCell(spacerCellAfter3);
                                    document.Add(spacerTableAfter3);
                                }
                                if (ds.Tables[4].Rows.Count > 0)
                                {
                                    document.Add(CreateTitle("Lookup Condition details", mustardYellow));
                                    document.Add(PdfdynamicTableGenration(ds.Tables[4]));
                                    PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                    PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                    {
                                        FixedHeight = fh,
                                        Border = PdfPCell.NO_BORDER
                                    };
                                    spacerTableAfter3.AddCell(spacerCellAfter3);
                                    document.Add(spacerTableAfter3);
                                }
                            }
                            else if (dt4.Rows[i]["Process Method"].ToString() == "QCD_FUNCTION")
                            {
                                if (ds.Tables[2].Rows.Count > 0)
                                {
                                    document.Add(CreateTitle("Function", mustardYellow));
                                    document.Add(PdfdynamicTableGenration(ds.Tables[2]));
                                    PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                    PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                    {
                                        FixedHeight = fh,
                                        Border = PdfPCell.NO_BORDER
                                    };
                                    spacerTableAfter3.AddCell(spacerCellAfter3);
                                    document.Add(spacerTableAfter3);
                                }
                            }
                        }
                    }
                    /* Table Ends PreProcess */



                    document.Close();
                    byte[] pdfBytes = ms.ToArray();

                    using (MemoryStream finalStream = new MemoryStream())
                    {
                        using (Document finalDocument = new Document(rec, 30f, 30f, 30f, 30f))
                        {
                            PdfCopy pdfCopy = new PdfCopy(finalDocument, finalStream);
							finalDocument.Open();
                            PdfReader tocReader = new PdfReader(GenerateTocPdf(tocEntries));
                            for (int i = 1; i <= tocReader.NumberOfPages; i++)
                            {
                                pdfCopy.AddPage(pdfCopy.GetImportedPage(tocReader, i));
                            }
                            PdfReader contentReader = new PdfReader(ms.ToArray());
                            for (int i = 1; i <= contentReader.NumberOfPages; i++)
                            {
                                pdfCopy.AddPage(pdfCopy.GetImportedPage(contentReader, i));
                            }
                            finalDocument.Close();
                        }
                        return finalStream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_report_reconversionhistory" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message, "pr_report_reconversionhistory", headerval.user_code, constring);
                return null;
            }
        }

        public byte[] ReconReportVersionhistoryData1(ReconReportVersionhistoryModel objReconReportVersionhistory, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                float fh = 8f;
                BaseColor mustardYellow = new BaseColor(235, 147, 22);
                BaseColor grassGreen = new BaseColor(0, 102, 0);
                BaseColor reconPurpple = new BaseColor(135, 46, 123);
                BaseColor ironbrown = new BaseColor(153, 0, 0);
                string logoPath = "D:\\user\\hema\\Recon\\ReconWeb\\ReconWeb\\Recon\\Recon_proto\\wwwroot\\Assets\\images\\footerlogo_new.png";
                DBManager dbManager = new DBManager(constring);
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objReconReportVersionhistory.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_version_code", objReconReportVersionhistory.in_version_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_report_reconversionhistory", CommandType.StoredProcedure, parameters.ToArray());
                if (ds.Tables.Count >= 3)
                {
                    ds.Tables[0].TableName = "Recondetail";
                    ds.Tables[1].TableName = "Rulelist";
                    ds.Tables[2].TableName = "themelist";
                    ds.Tables[3].TableName = "preprocesslist";
                }
                // Dynamic Table data
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                dt1 = ds.Tables["Recondetail"];
                dt2 = ds.Tables["Rulelist"];
                dt3 = ds.Tables["themelist"];
                dt4 = ds.Tables["preprocesslist"];
                Rectangle rec = new Rectangle(PageSize.A4);
                Dictionary<string, int> tocEntries = new Dictionary<string, int>();
                MemoryStream ms = new MemoryStream();
                using (Document document = new Document(rec, 30f, 30f, 30f, 30f))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
					document.Open();
                    BaseColor borderColor = new BaseColor(169, 169, 169);

                    /* Header Start */

                    // Input field
                    PdfPTable mainTable = new PdfPTable(3) { WidthPercentage = 100 };
                    mainTable.SetWidths(new float[] { 10f, 5f, 10f });

                    // Title
                    string mainTitle = "Recon Version History - " + objReconReportVersionhistory.in_version_code;
                    document.Add(CreateMainTitle1(mainTitle));
                    tocEntries.Add(mainTitle, writer.PageNumber);

                    // Recon Code Column
                    PdfPTable reconCodeTable = new PdfPTable(1);
                    reconCodeTable.AddCell(CreateLabelCell("Recon Code : " + dt1.Rows[0]["Recon Code"], true));

                    PdfPCell reconCodeCell = new PdfPCell(reconCodeTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                        BorderColor = borderColor
                    };
                    mainTable.AddCell(reconCodeCell);

                    // Add an empty blank space
                    mainTable.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });

                    // Recon Name Column
                    PdfPTable reconNameTable = new PdfPTable(1);
                    reconNameTable.AddCell(CreateLabelCell("Recon Name : " + dt1.Rows[0]["Recon Name"], true));

                    PdfPCell reconNameCell = new PdfPCell(reconNameTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                        BorderColor = borderColor
                    };
                    mainTable.AddCell(reconNameCell);

                    // Empty Line

                    PdfPCell blankCell = new PdfPCell(new Phrase(" "))
                    {
                        Colspan = 3,
                        FixedHeight = 8f, // Adjust height as needed
                        Border = PdfPCell.NO_BORDER
                    };

                    mainTable.AddCell(blankCell);

                    // History Version Column
                    PdfPTable historyVersionTable = new PdfPTable(1);
                    historyVersionTable.AddCell(CreateLabelCell("History Version : " + objReconReportVersionhistory.in_version_code, true));

                    PdfPCell historyVersionCell = new PdfPCell(historyVersionTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                        BorderColor = borderColor
                    };
                    mainTable.AddCell(historyVersionCell);

                    // Add an empty blank space
                    mainTable.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });

                    // Recon Type Column
                    PdfPTable reconTypeTable = new PdfPTable(1);
                    reconTypeTable.AddCell(CreateLabelCell("Recon Type : " + dt1.Rows[0]["Recon Type"], true));

                    PdfPCell reconTypeCell = new PdfPCell(reconTypeTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                        BorderColor = borderColor
                    };
                    mainTable.AddCell(reconTypeCell);

                    // Empty Line

                    PdfPCell blankCell1 = new PdfPCell(new Phrase(" "))
                    {
                        Colspan = 3,
                        FixedHeight = fh,
                        Border = PdfPCell.NO_BORDER
                    };

                    mainTable.AddCell(blankCell1);

                    // Period From Column
                    PdfPTable periodFromTable = new PdfPTable(1);
                    periodFromTable.AddCell(CreateLabelCell("Active From : " + dt1.Rows[0]["Period From"], true));

                    PdfPCell periodFromTypeCell = new PdfPCell(periodFromTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                        BorderColor = borderColor
                    };
                    mainTable.AddCell(periodFromTypeCell);

                    // Add an empty blank space
                    mainTable.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });

                    // Period To Column
                    if (dt1.Rows[0]["until_active_flag"].ToString() == "YES")
                    {
                        PdfPTable periodToTable = new PdfPTable(1);
                        periodToTable.AddCell(CreateLabelCell("Active To : " + "Until Inactive", true));

                        PdfPCell periodToTypeCell = new PdfPCell(periodToTable)
                        {
                            Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                            BackgroundColor = new BaseColor(230, 230, 250),
                            BorderColor = borderColor
                        };
                        mainTable.AddCell(periodToTypeCell);
                    }
                    else
                    {
                        PdfPTable periodToTable = new PdfPTable(1);
                        periodToTable.AddCell(CreateLabelCell("Active To : " + dt1.Rows[0]["Period To"], true));

                        PdfPCell periodToTypeCell = new PdfPCell(periodToTable)
                        {
                            Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                            BackgroundColor = new BaseColor(230, 230, 250),
                            BorderColor = borderColor
                        };
                        mainTable.AddCell(periodToTypeCell);
                    }

                    // Adding Blank Space

                    PdfPCell blankCell2 = new PdfPCell(new Phrase(" "))
                    {
                        Colspan = 3,
                        FixedHeight = fh,
                        Border = PdfPCell.NO_BORDER
                    };

                    mainTable.AddCell(blankCell2);

                    document.Add(mainTable);
                    /* Header Ends */

                    // List Table for Rule ,Theme and PreProcess

                    if (dt4.Rows.Count > 0)
                    {
                        string preprocessTitle = "PreProcess List";
                        document.Add(CreateTitle(preprocessTitle, mustardYellow));
                        tocEntries.Add(preprocessTitle, writer.PageNumber);
                        document.Add(PdfdynamicTableGenration(dt4));
                        PdfPTable spacerTableAfter = new PdfPTable(1);
                        PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
                        {
                            FixedHeight = fh,
                            Border = PdfPCell.NO_BORDER
                        };
                        spacerTableAfter.AddCell(spacerCellAfter);
                        document.Add(spacerTableAfter);
                    }

                    if (dt2.Rows.Count > 0)
                    {
                        string ruleListTitle = "Rule List";
                        document.Add(CreateTitle(ruleListTitle, mustardYellow));
                        tocEntries.Add(ruleListTitle, writer.PageNumber);
                        document.Add(PdfdynamicTableGenration(dt2));
                        PdfPTable spacerTableAfter = new PdfPTable(1);
                        PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
                        {
                            FixedHeight = fh,
                            Border = PdfPCell.NO_BORDER
                        };
                        spacerTableAfter.AddCell(spacerCellAfter);
                        document.Add(spacerTableAfter);
                    }

                    if (dt3.Rows.Count > 0)
                    {
                        string themeListTitle = "Theme List";
                        document.Add(CreateTitle(themeListTitle, mustardYellow));
                        tocEntries.Add(themeListTitle, writer.PageNumber);
                        document.Add(PdfdynamicTableGenration(dt3));
                    }
                    document.Close();
                }

                // Now create the final document with the TOC
                using (MemoryStream finalStream = new MemoryStream())
                {
                    using (Document finalDocument = new Document(rec, 30f, 30f, 30f, 30f))
                    {
                        PdfCopy pdfCopy = new PdfCopy(finalDocument, finalStream);
						PdfWriter writer = PdfWriter.GetInstance(finalDocument, finalStream);
						finalDocument.Open();

                        // Add TOC at the beginning
                        PdfReader tocReader = new PdfReader(GenerateTocPdf(tocEntries));
                        for (int i = 1; i <= tocReader.NumberOfPages; i++)
                        {
                            pdfCopy.AddPage(pdfCopy.GetImportedPage(tocReader, i));
                        }

                        // Add the main content
                        PdfReader contentReader = new PdfReader(ms.ToArray());
                        for (int i = 1; i <= contentReader.NumberOfPages; i++)
                        {
                            pdfCopy.AddPage(pdfCopy.GetImportedPage(contentReader, i));
                        }
                        finalDocument.Close();
                    }
                    return finalStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new ApplicationException("Error generating PDF", ex);
            }
        }

        private byte[] GenerateTocPdf(Dictionary<string, int> tocEntries)
        {
            using (MemoryStream tocStream = new MemoryStream())
            {
                using (Document tocDocument = new Document(PageSize.A4, 30f, 30f, 30f, 30f))
                {
                    PdfWriter tocWriter = PdfWriter.GetInstance(tocDocument, tocStream);
					tocDocument.Open();
                    tocDocument.Add(new Paragraph("Table of Contents", new Font(Font.FontFamily.HELVETICA, 20)));

                    foreach (var entry in tocEntries)
                    {
                        Paragraph p = new Paragraph($"{entry.Key} ....... {entry.Value}", new Font(Font.FontFamily.HELVETICA, 12));
                        tocDocument.Add(p);
                    }

                    tocDocument.Close();
                }
                return tocStream.ToArray();
            }
        }

    }
}

