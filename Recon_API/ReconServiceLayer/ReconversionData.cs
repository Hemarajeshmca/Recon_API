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
using System.Diagnostics;

namespace ReconDataLayer
{
    public class ReconversionData
	{
        private Image _watermarkImage;
        DataSet ds = new DataSet();
		DataTable result = new DataTable();
		DBManager dbManager = new DBManager("ConnectionString");
		List<IDbDataParameter>? parameters;
		public DataSet ReconVersionfetchdata(ReconVersionmodellist Objmodel, UserManagementModel.headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
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



        public byte[] ReconReportVersionhistoryData1(ReconReportVersionhistoryModel objReconReportVersionhistory, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
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
					ds.Tables[2].TableName = "preprocess";
				}
                
                MemoryStream ms = new MemoryStream();
                Rectangle rec = new Rectangle(PageSize.A4);
                using (Document document = new Document(rec, 30f, 30f, 30f, 30f))
                {
                    // Dynamic Table data
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();
                    dt1 = ds.Tables["Recondetail"];
                    dt2 = ds.Tables["Rulelist"];
                    dt3 = ds.Tables["preprocess"];
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
					writer.PageEvent = new PdfWatermarkHandler();
					//string watermarkImagePath = Path.Combine(Directory.GetCurrentDirectory(), "Image", "watermark.png");
					//Image watermarkImage = Image.GetInstance(watermarkImagePath);
					//watermarkImage.SetAbsolutePosition(200, 400); // Adjust position as needed
					//watermarkImage.ScaleToFit(200, 200); // Adjust size as needed

					//// Add the watermark handler
					//writer.PageEvent = new PdfWatermarkHandler(watermarkImage);

					document.Open();

					/* Header Start */

					// Heading
					//PdfContentByte content = writer.DirectContent;
					//iTextSharp.text.Rectangle rectangle = new iTextSharp.text.Rectangle(document.PageSize);
					//rectangle.Left += document.LeftMargin - 5;
					//rectangle.Right -= document.RightMargin - 5;
					//rectangle.Top -= document.TopMargin - 5;
					//rectangle.Bottom += document.BottomMargin - 5;
					//content.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
					//content.Stroke();

					//iTextSharp.text.Font NormalFont = iTextSharp.text.FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK); content.SetColorStroke(BaseColor.GRAY); // setting the color of the border to black

					// Input field
					PdfPTable mainTable = new PdfPTable(3) { WidthPercentage = 100 };
                    mainTable.SetWidths(new float[] { 10f, 5f, 10f });

					// Title
					document.Add(CreateMainTitle1("Recon Version History - " + objReconReportVersionhistory.in_version_code));
					
					// Recon Code Column
					PdfPTable reconCodeTable = new PdfPTable(1);
                    reconCodeTable.AddCell(CreateLabelCell("Recon Code : " + dt1.Rows[0]["Recon Code"], true));

                    PdfPCell reconCodeCell = new PdfPCell(reconCodeTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250),
                       
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
                            BackgroundColor = new BaseColor(230, 230, 250)
                        };
                        mainTable.AddCell(reconNameCell);


                    // Empty Line

                    PdfPCell blankCell = new PdfPCell(new Phrase(" "))
                    {
                        Colspan = 3,
                        FixedHeight = 15f, // Adjust height as needed
                        Border = PdfPCell.NO_BORDER
                    };

                    mainTable.AddCell(blankCell);


                    // History Version Column
                    PdfPTable historyVersionTable = new PdfPTable(1);
                    historyVersionTable.AddCell(CreateLabelCell("History Version : " + objReconReportVersionhistory.in_version_code, true));

                    PdfPCell historyVersionCell = new PdfPCell(historyVersionTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250)
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
                        BackgroundColor = new BaseColor(230, 230, 250)
                    };
                    mainTable.AddCell(reconTypeCell);

                    // Empty Line

                    PdfPCell blankCell1 = new PdfPCell(new Phrase(" "))
                    {
                        Colspan = 3,
                        FixedHeight = 15f, // Adjust height as needed
                        Border = PdfPCell.NO_BORDER
                    };

                    mainTable.AddCell(blankCell1);

                    // Period From Column
                    PdfPTable periodFromTable = new PdfPTable(1);
                    periodFromTable.AddCell(CreateLabelCell("Active From : " + dt1.Rows[0]["Period From"], true));

                    PdfPCell periodFromTypeCell = new PdfPCell(periodFromTable)
                    {
                        Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                        BackgroundColor = new BaseColor(230, 230, 250)
                    };
                    mainTable.AddCell(periodFromTypeCell);

                    // Add an empty blank space
                    mainTable.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });

                    // Period To Column
                    if(dt1.Rows[0]["until_active_flag"].ToString() == "YES")
                    {
                        PdfPTable periodToTable = new PdfPTable(1);
                        periodToTable.AddCell(CreateLabelCell("Active To : " + "Until Inactive", true));

                        PdfPCell periodToTypeCell = new PdfPCell(periodToTable)
                        {
                            Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                            BackgroundColor = new BaseColor(230, 230, 250)
                        };
                        mainTable.AddCell(periodToTypeCell);
                    } else
                    {
                        PdfPTable periodToTable = new PdfPTable(1);
                        periodToTable.AddCell(CreateLabelCell("Active To : " + dt1.Rows[0]["Period To"], true));

                        PdfPCell periodToTypeCell = new PdfPCell(periodToTable)
                        {
                            Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                            BackgroundColor = new BaseColor(230, 230, 250)
                        };
                        mainTable.AddCell(periodToTypeCell);
                    }

                    //document.Add(new Chunk("\n", NormalFont));

                    // Adding Blank Space

                    PdfPCell blankCell2 = new PdfPCell(new Phrase(" "))
                    {
                        Colspan = 3,
                        FixedHeight = 15f, // Adjust height as needed
                        Border = PdfPCell.NO_BORDER
                    };

                    mainTable.AddCell(blankCell2);
                    document.Add(mainTable);
                    /* Header Ends */

                    /* Table Starts Rule */

                    if (dt2.Rows.Count > 0)
                    {
                        for (int i=0; i<dt2.Rows.Count; i++)
                        {
                            PdfPTable mainTable1 = new PdfPTable(3) { WidthPercentage = 100 };
                            mainTable1.SetWidths(new float[] { 10f, 10f, 10f });
                            parameters = new List<IDbDataParameter>(); 
                            parameters.Add(dbManager.CreateParameter("in_rule_code", Convert.ToString(dt2.Rows[i]["rule_code"]), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_recon_code", Convert.ToString(dt2.Rows[i]["recon_code"]), DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_rule_version", Convert.ToString(objReconReportVersionhistory.in_version_code),DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                            parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));

                            ds = dbManager.execStoredProcedure("pr_report_rulecondition", CommandType.StoredProcedure, parameters.ToArray());

							// Rule Code Column
							document.Add(CreateTitle("Rule Details"));

							PdfPTable ruleCodeTable = new PdfPTable(1);
                            ruleCodeTable.AddCell(CreateLabelCell("Rule Code : " + dt2.Rows[i]["rule_code"], true));

                            PdfPCell ruleCodeCell = new PdfPCell(ruleCodeTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250),

                            };
                            mainTable1.AddCell(ruleCodeCell);

							// Rule Name column

							PdfPTable ruleNameTable = new PdfPTable(1);
							ruleNameTable.AddCell(CreateLabelCell("Rule Name : " + dt2.Rows[i]["rule_name"], true));

							PdfPCell ruleNameCell = new PdfPCell(ruleNameTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleNameCell);							
							
							//Rule Applied Column
							PdfPTable ruleAppliedTable = new PdfPTable(1);
							ruleAppliedTable.AddCell(CreateLabelCell("Rule Applied On : " + dt2.Rows[i]["Rule Applied On"], true));

							PdfPCell ruleAppliedCell = new PdfPCell(ruleAppliedTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),

							};
							mainTable1.AddCell(ruleAppliedCell);

							PdfPCell blankCell3 = new PdfPCell(new Phrase(" "))
							{
								Colspan = 3,
								FixedHeight = 15f, // Adjust height as needed
								Border = PdfPCell.NO_BORDER
							};

							mainTable1.AddCell(blankCell3);

							// Source Dataset Column
							PdfPTable ruleSourceTable = new PdfPTable(1);
							ruleSourceTable.AddCell(CreateLabelCell("Source Dataset : " + dt2.Rows[i]["source_dataset"], true));

							PdfPCell ruleSourceCell = new PdfPCell(ruleSourceTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleSourceCell);


							// Source Account Mode Column
							PdfPTable ruleSourceModeTable = new PdfPTable(1);
							ruleSourceModeTable.AddCell(CreateLabelCell("Source Acc Mode : " + dt2.Rows[i]["Source Acc Mode"], true));

							PdfPCell ruleSourceModeCell = new PdfPCell(ruleSourceModeTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleSourceModeCell);

							//Comparison Dataset
							PdfPTable ruleComparisonTable = new PdfPTable(1);
							ruleComparisonTable.AddCell(CreateLabelCell("Comparison Dataset : " + dt2.Rows[i]["comparison_dataset"], true));

							PdfPCell ruleComparisonCell = new PdfPCell(ruleComparisonTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleComparisonCell);

							PdfPCell blankCell5 = new PdfPCell(new Phrase(" "))
							{
								Colspan = 3,
								FixedHeight = 15f, // Adjust height as needed
								Border = PdfPCell.NO_BORDER
							};

							mainTable1.AddCell(blankCell5);

							//Comparison Account Mode Dataset
							PdfPTable ruleComparisonModeTable = new PdfPTable(1);
							ruleComparisonModeTable.AddCell(CreateLabelCell("Comparison Acc Mode : " + dt2.Rows[i]["Comparison Acc Mode"], true));

							PdfPCell ruleComparisonModeCell = new PdfPCell(ruleComparisonModeTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleComparisonModeCell);

							// Group Flag Column
							PdfPTable ruleGroupTable = new PdfPTable(1);
							ruleGroupTable.AddCell(CreateLabelCell("Rule Group : " + dt2.Rows[i]["Group Flag"], true));

							PdfPCell ruleGroupCell = new PdfPCell(ruleGroupTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleGroupCell);

							// Rule Order Column
							PdfPTable ruleOrderTable = new PdfPTable(1);
							ruleOrderTable.AddCell(CreateLabelCell("Rule Order : " + dt2.Rows[i]["Rule Order"], true));

							PdfPCell ruleOrderCell = new PdfPCell(ruleOrderTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleOrderCell);

							PdfPCell blankCell4 = new PdfPCell(new Phrase(" "))
							{
								Colspan = 3,
								FixedHeight = 15f, // Adjust height as needed
								Border = PdfPCell.NO_BORDER
							};

							mainTable1.AddCell(blankCell4);

							document.Add(mainTable1);
                            //Table and space between                            

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                document.Add(CreateTitle("Rule Condition"));
                                document.Add(PdfdynamicTableGenration(ds.Tables[0]));
                                PdfPTable spacerTableAfter = new PdfPTable(1);
                                PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = 15f,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter.AddCell(spacerCellAfter);
                                document.Add(spacerTableAfter);
                            } else
                            {
                                document.Add(CreateTitle("Rule Condition - No Records Found"));
                            }

                            //Table and space between
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                document.Add(CreateTitle("Rule Source Filter"));
                                document.Add(PdfdynamicTableGenration(ds.Tables[1]));
                                PdfPTable spacerTableAfter1 = new PdfPTable(1);
                                PdfPCell spacerCellAfter1 = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = 15f,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter1.AddCell(spacerCellAfter1);
                                document.Add(spacerTableAfter1);
                            } else
                            {
                                document.Add(CreateTitle("Rule Source Filter - No Records Found"));
                            }

                            //Table and space between
                            if (ds.Tables[2].Rows.Count > 0) {
                                document.Add(CreateTitle("Rule Comparision Filter"));
                                document.Add(PdfdynamicTableGenration(ds.Tables[2]));
                                PdfPTable spacerTableAfter2 = new PdfPTable(1);
                                PdfPCell spacerCellAfter2 = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = 15f,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter2.AddCell(spacerCellAfter2);
                                document.Add(spacerTableAfter2);
                            } else
                            {
                                document.Add(CreateTitle("Rule Comparision Filter - No Records Found"));
                            }

                            //Table and space between
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                document.Add(CreateTitle("Rule Group Filter"));
                                document.Add(PdfdynamicTableGenration(ds.Tables[3]));
                                PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                {
                                    FixedHeight = 15f,
                                    Border = PdfPCell.NO_BORDER
                                };
                                spacerTableAfter3.AddCell(spacerCellAfter3);
                                document.Add(spacerTableAfter3);
                            } else
                            {
                                document.Add(CreateTitle("Rule Group Filter - No Records Found"));
                            }
                        }
                    }
                    
                    /* Table Ends Rule */

                    /* Table Starts Theme */
                    if(dt3.Rows.Count > 0)
                    {
						for (int i = 0; i < dt3.Rows.Count; i++)
                        {
							PdfPTable mainTable2 = new PdfPTable(3) { WidthPercentage = 100 }; // PdfPTable(3) Number of columns
							mainTable2.SetWidths(new float[] { 10f, 10f, 10f }); // set width for the three column
							parameters = new List<IDbDataParameter>();
							parameters.Add(dbManager.CreateParameter("in_theme_code", Convert.ToString(dt3.Rows[i]["theme_code"]), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_recon_code", Convert.ToString(dt2.Rows[i]["recon_code"]), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_theme_version", Convert.ToString(objReconReportVersionhistory.in_version_code), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
							parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
							parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));

							ds = dbManager.execStoredProcedure("pr_report_themedetails", CommandType.StoredProcedure, parameters.ToArray());
							
                            document.Add(CreateTitle("Theme Details"));

                            //Theme Code
							PdfPTable themeCodeTable = new PdfPTable(1);
							themeCodeTable.AddCell(CreateLabelCell("Theme Code : " + dt3.Rows[i]["theme_code"], true));

							PdfPCell themeCodeCell = new PdfPCell(themeCodeTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),

							};
							mainTable2.AddCell(themeCodeCell);

							// Theme Name Column
							PdfPTable themeNameTable = new PdfPTable(1);
							themeNameTable.AddCell(CreateLabelCell("Theme Name : " + dt3.Rows[i]["theme_name"], true));

							PdfPCell themeNameCell = new PdfPCell(themeNameTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable2.AddCell(themeNameCell);

							//Theme Order
							PdfPTable themeOrderTable = new PdfPTable(1);
							themeOrderTable.AddCell(CreateLabelCell("Theme Order : " + dt3.Rows[i]["theme_order"], true));

							PdfPCell themeOrderCell = new PdfPCell(themeOrderTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),

							};
							mainTable2.AddCell(themeOrderCell);

							PdfPCell blankCell3 = new PdfPCell(new Phrase(" "))
                            {
                                Colspan = 3,
                                FixedHeight = 15f, // Adjust height as needed
                                Border = PdfPCell.NO_BORDER
                            };

                            mainTable2.AddCell(blankCell3);

                            // Hold Flag Column
                            PdfPTable themeholdTable = new PdfPTable(1);
                            themeholdTable.AddCell(CreateLabelCell("Hold Flag : " + dt3.Rows[i]["hold_flag_desc"], true));

                            PdfPCell themeHoldCell = new PdfPCell(themeholdTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250)
                            };
                            mainTable2.AddCell(themeHoldCell);


                            // Theme Type Column
                            PdfPTable themeTypeTable = new PdfPTable(1);
                            themeTypeTable.AddCell(CreateLabelCell("Theme Type: " + dt3.Rows[i]["theme_type"], true));

                            PdfPCell themeTypeCell = new PdfPCell(themeTypeTable)
                            {
                                Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
                                BackgroundColor = new BaseColor(230, 230, 250)
                            };
                            mainTable2.AddCell(themeTypeCell);

                           
                            // Add an empty blank space
                            mainTable2.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });

                            //PdfPCell blankCell4 = new PdfPCell(new Phrase(" "))
                            //{
                            //	Colspan = 3,
                            //	FixedHeight = 15f, // Adjust height as needed
                            //	Border = PdfPCell.NO_BORDER
                            //};

                            //mainTable2.AddCell(blankCell4);

                            document.Add(mainTable2);
                            if (ds.Tables[1].Rows.Count > 0)
							{
								document.Add(CreateTitle("Theme Condition"));
								document.Add(PdfdynamicTableGenration(ds.Tables[1]));
								PdfPTable spacerTableAfter = new PdfPTable(1);
								PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter.AddCell(spacerCellAfter);
								document.Add(spacerTableAfter);
							}
							else
							{
								document.Add(CreateTitle("Theme Condition - No Records Found"));
							}
							if (ds.Tables[2].Rows.Count > 0)
							{
								document.Add(CreateTitle("Theme Source Identifier"));
								document.Add(PdfdynamicTableGenration(ds.Tables[2]));
								PdfPTable spacerTableAfter3 = new PdfPTable(1);
								PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter3.AddCell(spacerCellAfter3);
								document.Add(spacerTableAfter3);
							}
							else
							{
								document.Add(CreateTitle("Theme Source Identifier - No Records Found"));
							}
							if (ds.Tables[3].Rows.Count > 0)
							{
								document.Add(CreateTitle("Theme Comparision Identifier"));
								document.Add(PdfdynamicTableGenration(ds.Tables[3]));
								PdfPTable spacerTableAfter3 = new PdfPTable(1);
								PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter3.AddCell(spacerCellAfter3);
								document.Add(spacerTableAfter3);
							}
							else
							{
								document.Add(CreateTitle("Theme Comparision Identifier - No Records Found"));
							}
						}

					}

                    /* Table Ends Theme */

                    document.Close();
                    byte[] pdfBytes = ms.ToArray();
                }
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_report_reconversionhistory" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message, "pr_report_reconversionhistory", headerval.user_code, constring);
                return null;
            }
        }

        private PdfPTable PdfdynamicTableGenration(DataTable dt)
        {
            PdfPTable table = new PdfPTable(dt.Columns.Count) { WidthPercentage = 100 };

            foreach (DataColumn column in dt.Columns)
            {
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE);
                table.AddCell(CreateHeaderCell(column.ColumnName, headerFont, new BaseColor(70, 130, 180)));
            }

            // Add rows
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    Font dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);
                    PdfPCell cell = new PdfPCell(new Phrase(row[column].ToString(), dataFont));
                    if (column.Ordinal >= 2)
                    {
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        FontFactory.GetFont(FontFactory.HELVETICA, 7, BaseColor.BLACK);
                    }
                    table.AddCell(cell);
                }
            }

            return table;
        }
        private PdfPCell CreateLabelCell(string labelText, bool isRequired)
        {
            Font font = new Font(Font.FontFamily.HELVETICA, 9f, Font.NORMAL);
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
            };
            return headerCell;
        }

		private Paragraph CreateMainTitle(string title)
		{
			iTextSharp.text.Font boldFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD); 
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
			boldFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
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
		private Paragraph CreateTitle(string title)
        {
            iTextSharp.text.Font boldFont = new iTextSharp.text.Font();
            boldFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
            Paragraph prgHeading = new Paragraph();
			string camelCaseTitle = ToInitialCaps(title);

			prgHeading.Alignment = Element.ALIGN_LEFT;
            Chunk headingChunk = new Chunk(camelCaseTitle, boldFont);
            headingChunk.SetUnderline(0.5f, -1.5f);
            prgHeading.Add(headingChunk);
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
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
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
					PdfWriter writer = PdfWriter.GetInstance(document, ms);
					writer.PageEvent = new PdfWatermarkHandler();
					document.Open();

					/* Header Start */

					// Input field
					PdfPTable mainTable = new PdfPTable(3) { WidthPercentage = 100 };
					mainTable.SetWidths(new float[] { 10f, 5f, 10f });

					// Title
					document.Add(CreateMainTitle1("Recon Version History - " + objReconReportVersionhistory.in_version_code));

					// Recon Code Column
					PdfPTable reconCodeTable = new PdfPTable(1);
					reconCodeTable.AddCell(CreateLabelCell("Recon Code : " + dt1.Rows[0]["Recon Code"], true));

					PdfPCell reconCodeCell = new PdfPCell(reconCodeTable)
					{
						Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
						BackgroundColor = new BaseColor(230, 230, 250),

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
						BackgroundColor = new BaseColor(230, 230, 250)
					};
					mainTable.AddCell(reconNameCell);


					// Empty Line

					PdfPCell blankCell = new PdfPCell(new Phrase(" "))
					{
						Colspan = 3,
						FixedHeight = 15f, // Adjust height as needed
						Border = PdfPCell.NO_BORDER
					};

					mainTable.AddCell(blankCell);


					// History Version Column
					PdfPTable historyVersionTable = new PdfPTable(1);
					historyVersionTable.AddCell(CreateLabelCell("History Version : " + objReconReportVersionhistory.in_version_code, true));

					PdfPCell historyVersionCell = new PdfPCell(historyVersionTable)
					{
						Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
						BackgroundColor = new BaseColor(230, 230, 250)
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
						BackgroundColor = new BaseColor(230, 230, 250)
					};
					mainTable.AddCell(reconTypeCell);

					// Empty Line

					PdfPCell blankCell1 = new PdfPCell(new Phrase(" "))
					{
						Colspan = 3,
						FixedHeight = 15f, // Adjust height as needed
						Border = PdfPCell.NO_BORDER
					};

					mainTable.AddCell(blankCell1);

					// Period From Column
					PdfPTable periodFromTable = new PdfPTable(1);
					periodFromTable.AddCell(CreateLabelCell("Active From : " + dt1.Rows[0]["Period From"], true));

					PdfPCell periodFromTypeCell = new PdfPCell(periodFromTable)
					{
						Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
						BackgroundColor = new BaseColor(230, 230, 250)
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
							BackgroundColor = new BaseColor(230, 230, 250)
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
							BackgroundColor = new BaseColor(230, 230, 250)
						};
						mainTable.AddCell(periodToTypeCell);
					}

					// Adding Blank Space

					PdfPCell blankCell2 = new PdfPCell(new Phrase(" "))
					{
						Colspan = 3,
						FixedHeight = 15f, // Adjust height as needed
						Border = PdfPCell.NO_BORDER
					};

					mainTable.AddCell(blankCell2);
					document.Add(mainTable);
					/* Header Ends */

					/* Table Starts Rule */

					if (dt2.Rows.Count > 0)
					{
						for (int i = 0; i < dt2.Rows.Count; i++)
						{
							PdfPTable mainTable1 = new PdfPTable(3) { WidthPercentage = 100 };
							mainTable1.SetWidths(new float[] { 10f, 10f, 10f });
							parameters = new List<IDbDataParameter>();
							parameters.Add(dbManager.CreateParameter("in_rule_code", Convert.ToString(dt2.Rows[i]["rule_code"]), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_recon_code", Convert.ToString(dt2.Rows[i]["recon_code"]), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_rule_version", Convert.ToString(objReconReportVersionhistory.in_version_code), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
							parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
							parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));

							ds = dbManager.execStoredProcedure("pr_report_rulecondition", CommandType.StoredProcedure, parameters.ToArray());

							// Rule Code Column
							document.Add(CreateTitle("Rule Details"));

							PdfPTable ruleCodeTable = new PdfPTable(1);
							ruleCodeTable.AddCell(CreateLabelCell("Rule Code : " + dt2.Rows[i]["rule_code"], true));

							PdfPCell ruleCodeCell = new PdfPCell(ruleCodeTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),

							};
							mainTable1.AddCell(ruleCodeCell);

							// Rule Name column

							PdfPTable ruleNameTable = new PdfPTable(1);
							ruleNameTable.AddCell(CreateLabelCell("Rule Name : " + dt2.Rows[i]["rule_name"], true));

							PdfPCell ruleNameCell = new PdfPCell(ruleNameTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleNameCell);

							//Rule Applied Column
							PdfPTable ruleAppliedTable = new PdfPTable(1);
							ruleAppliedTable.AddCell(CreateLabelCell("Rule Applied On : " + dt2.Rows[i]["Rule Applied On"], true));

							PdfPCell ruleAppliedCell = new PdfPCell(ruleAppliedTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),

							};
							mainTable1.AddCell(ruleAppliedCell);

							PdfPCell blankCell3 = new PdfPCell(new Phrase(" "))
							{
								Colspan = 3,
								FixedHeight = 15f, // Adjust height as needed
								Border = PdfPCell.NO_BORDER
							};

							mainTable1.AddCell(blankCell3);

							// Source Dataset Column
							PdfPTable ruleSourceTable = new PdfPTable(1);
							ruleSourceTable.AddCell(CreateLabelCell("Source Dataset : " + dt2.Rows[i]["source_dataset"], true));

							PdfPCell ruleSourceCell = new PdfPCell(ruleSourceTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleSourceCell);


							// Source Account Mode Column
							PdfPTable ruleSourceModeTable = new PdfPTable(1);
							ruleSourceModeTable.AddCell(CreateLabelCell("Source Acc Mode : " + dt2.Rows[i]["Source Acc Mode"], true));

							PdfPCell ruleSourceModeCell = new PdfPCell(ruleSourceModeTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleSourceModeCell);

							//Comparison Dataset
							PdfPTable ruleComparisonTable = new PdfPTable(1);
							ruleComparisonTable.AddCell(CreateLabelCell("Comparison Dataset : " + dt2.Rows[i]["comparison_dataset"], true));

							PdfPCell ruleComparisonCell = new PdfPCell(ruleComparisonTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleComparisonCell);

							PdfPCell blankCell5 = new PdfPCell(new Phrase(" "))
							{
								Colspan = 3,
								FixedHeight = 15f, // Adjust height as needed
								Border = PdfPCell.NO_BORDER
							};

							mainTable1.AddCell(blankCell5);

							//Comparison Account Mode Dataset
							PdfPTable ruleComparisonModeTable = new PdfPTable(1);
							ruleComparisonModeTable.AddCell(CreateLabelCell("Comparison Acc Mode : " + dt2.Rows[i]["Comparison Acc Mode"], true));

							PdfPCell ruleComparisonModeCell = new PdfPCell(ruleComparisonModeTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleComparisonModeCell);

							// Group Flag Column
							PdfPTable ruleGroupTable = new PdfPTable(1);
							ruleGroupTable.AddCell(CreateLabelCell("Rule Group : " + dt2.Rows[i]["Group Flag"], true));

							PdfPCell ruleGroupCell = new PdfPCell(ruleGroupTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleGroupCell);

							// Rule Order Column
							PdfPTable ruleOrderTable = new PdfPTable(1);
							ruleOrderTable.AddCell(CreateLabelCell("Rule Order : " + dt2.Rows[i]["Rule Order"], true));

							PdfPCell ruleOrderCell = new PdfPCell(ruleOrderTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable1.AddCell(ruleOrderCell);

							PdfPCell blankCell4 = new PdfPCell(new Phrase(" "))
							{
								Colspan = 3,
								FixedHeight = 15f, // Adjust height as needed
								Border = PdfPCell.NO_BORDER
							};

							mainTable1.AddCell(blankCell4);

							document.Add(mainTable1);
							//Table and space between                            

							if (ds.Tables[0].Rows.Count > 0)
							{
								document.Add(CreateTitle("Rule Condition"));
								document.Add(PdfdynamicTableGenration(ds.Tables[0]));
								PdfPTable spacerTableAfter = new PdfPTable(1);
								PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter.AddCell(spacerCellAfter);
								document.Add(spacerTableAfter);
							}
							else
							{
								document.Add(CreateTitle("Rule Condition - No Records Found"));
							}

							//Table and space between
							if (ds.Tables[1].Rows.Count > 0)
							{
								document.Add(CreateTitle("Rule Source Filter"));
								document.Add(PdfdynamicTableGenration(ds.Tables[1]));
								PdfPTable spacerTableAfter1 = new PdfPTable(1);
								PdfPCell spacerCellAfter1 = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter1.AddCell(spacerCellAfter1);
								document.Add(spacerTableAfter1);
							}
							else
							{
								document.Add(CreateTitle("Rule Source Filter - No Records Found"));
							}

							//Table and space between
							if (ds.Tables[2].Rows.Count > 0)
							{
								document.Add(CreateTitle("Rule Comparision Filter"));
								document.Add(PdfdynamicTableGenration(ds.Tables[2]));
								PdfPTable spacerTableAfter2 = new PdfPTable(1);
								PdfPCell spacerCellAfter2 = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter2.AddCell(spacerCellAfter2);
								document.Add(spacerTableAfter2);
							}
							else
							{
								document.Add(CreateTitle("Rule Comparision Filter - No Records Found"));
							}

							//Table and space between
							if (ds.Tables[2].Rows.Count > 0)
							{
								document.Add(CreateTitle("Rule Group Filter"));
								document.Add(PdfdynamicTableGenration(ds.Tables[3]));
								PdfPTable spacerTableAfter3 = new PdfPTable(1);
								PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter3.AddCell(spacerCellAfter3);
								document.Add(spacerTableAfter3);
							}
							else
							{
								document.Add(CreateTitle("Rule Group Filter - No Records Found"));
							}
						}
					}

					/* Table Ends Rule */

					/* Table Starts Theme */
					if (dt3.Rows.Count > 0)
					{
						for (int i = 0; i < dt3.Rows.Count; i++)
						{
							PdfPTable mainTable2 = new PdfPTable(3) { WidthPercentage = 100 }; // PdfPTable(3) Number of columns
							mainTable2.SetWidths(new float[] { 10f, 10f, 10f }); // set width for the three column
							parameters = new List<IDbDataParameter>();
							parameters.Add(dbManager.CreateParameter("in_theme_code", Convert.ToString(dt3.Rows[i]["theme_code"]), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_recon_code", Convert.ToString(dt2.Rows[i]["recon_code"]), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_theme_version", Convert.ToString(objReconReportVersionhistory.in_version_code), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
							parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
							parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));

							ds = dbManager.execStoredProcedure("pr_report_themedetails", CommandType.StoredProcedure, parameters.ToArray());

							document.Add(CreateTitle("Theme Details"));

							//Theme Code
							PdfPTable themeCodeTable = new PdfPTable(1);
							themeCodeTable.AddCell(CreateLabelCell("Theme Code : " + dt3.Rows[i]["theme_code"], true));

							PdfPCell themeCodeCell = new PdfPCell(themeCodeTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),

							};
							mainTable2.AddCell(themeCodeCell);

							// Theme Name Column
							PdfPTable themeNameTable = new PdfPTable(1);
							themeNameTable.AddCell(CreateLabelCell("Theme Name : " + dt3.Rows[i]["theme_name"], true));

							PdfPCell themeNameCell = new PdfPCell(themeNameTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable2.AddCell(themeNameCell);

							//Theme Order
							PdfPTable themeOrderTable = new PdfPTable(1);
							themeOrderTable.AddCell(CreateLabelCell("Theme Order : " + dt3.Rows[i]["theme_order"], true));

							PdfPCell themeOrderCell = new PdfPCell(themeOrderTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),

							};
							mainTable2.AddCell(themeOrderCell);

							PdfPCell blankCell3 = new PdfPCell(new Phrase(" "))
							{
								Colspan = 3,
								FixedHeight = 15f, // Adjust height as needed
								Border = PdfPCell.NO_BORDER
							};

							mainTable2.AddCell(blankCell3);

							// Hold Flag Column
							PdfPTable themeholdTable = new PdfPTable(1);
							themeholdTable.AddCell(CreateLabelCell("Hold Flag : " + dt3.Rows[i]["hold_flag_desc"], true));

							PdfPCell themeHoldCell = new PdfPCell(themeholdTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable2.AddCell(themeHoldCell);


							// Theme Type Column
							PdfPTable themeTypeTable = new PdfPTable(1);
							themeTypeTable.AddCell(CreateLabelCell("Theme Type: " + dt3.Rows[i]["theme_type"], true));

							PdfPCell themeTypeCell = new PdfPCell(themeTypeTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250)
							};
							mainTable2.AddCell(themeTypeCell);


							// Add an empty blank space
							mainTable2.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });

							//PdfPCell blankCell4 = new PdfPCell(new Phrase(" "))
							//{
							//	Colspan = 3,
							//	FixedHeight = 15f, // Adjust height as needed
							//	Border = PdfPCell.NO_BORDER
							//};

							//mainTable2.AddCell(blankCell4);

							document.Add(mainTable2);
							if (ds.Tables[1].Rows.Count > 0)
							{
								document.Add(CreateTitle("Theme Condition"));
								document.Add(PdfdynamicTableGenration(ds.Tables[1]));
								PdfPTable spacerTableAfter = new PdfPTable(1);
								PdfPCell spacerCellAfter = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter.AddCell(spacerCellAfter);
								document.Add(spacerTableAfter);
							}
							else
							{
								document.Add(CreateTitle("Theme Condition - No Records Found"));
							}
							if (ds.Tables[2].Rows.Count > 0)
							{
								document.Add(CreateTitle("Theme Source Identifier"));
								document.Add(PdfdynamicTableGenration(ds.Tables[2]));
								PdfPTable spacerTableAfter3 = new PdfPTable(1);
								PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter3.AddCell(spacerCellAfter3);
								document.Add(spacerTableAfter3);
							}
							else
							{
								document.Add(CreateTitle("Theme Source Identifier - No Records Found"));
							}
							if (ds.Tables[3].Rows.Count > 0)
							{
								document.Add(CreateTitle("Theme Comparision Identifier"));
								document.Add(PdfdynamicTableGenration(ds.Tables[3]));
								PdfPTable spacerTableAfter3 = new PdfPTable(1);
								PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter3.AddCell(spacerCellAfter3);
								document.Add(spacerTableAfter3);
							}
							else
							{
								document.Add(CreateTitle("Theme Comparision Identifier - No Records Found"));
							}
						}

					}

					/* Table Ends Theme */


					/* Table Starts PreProcess */
					if (dt4.Rows.Count > 0)
					{
						for (int i = 0; i < dt4.Rows.Count; i++)
						{
							PdfPTable mainTable3 = new PdfPTable(3) { WidthPercentage = 100 }; // PdfPTable(3) Number of columns
							mainTable3.SetWidths(new float[] { 10f, 10f, 10f }); // set width for the three column
							parameters = new List<IDbDataParameter>();
							parameters.Add(dbManager.CreateParameter("in_preprocess_code", Convert.ToString(dt4.Rows[i]["preprocess_code"]), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_recon_code", Convert.ToString(dt4.Rows[i]["recon_code"]), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_version_code", Convert.ToString(objReconReportVersionhistory.in_version_code), DbType.String));
							parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
							parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
							parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
							ds = dbManager.execStoredProcedure("pr_report_preprocessdetails", CommandType.StoredProcedure, parameters.ToArray());
							document.Add(CreateTitle("Preprocess Details"));
							//PreProcess Code
							PdfPTable preprocessCodeTable = new PdfPTable(1);
							preprocessCodeTable.AddCell(CreateLabelCell("PreProcess Code : " + dt4.Rows[i]["preprocess_code"], true));

							PdfPCell preprocessCodeCell = new PdfPCell(preprocessCodeTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),

							};
							mainTable3.AddCell(preprocessCodeCell);

							//PreProcess Name
							PdfPTable preprocessNameTable = new PdfPTable(1);
							preprocessNameTable.AddCell(CreateLabelCell("PreProcess Name : " + dt4.Rows[i]["preprocess_desc"], true));

							PdfPCell preprocessNameCell = new PdfPCell(preprocessNameTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),

							};
							mainTable3.AddCell(preprocessNameCell);

							//PreProcess Method
							PdfPTable preprocessMethodTable = new PdfPTable(1);
							preprocessMethodTable.AddCell(CreateLabelCell("PreProcess Method : " + dt4.Rows[i]["process_method"], true));

							PdfPCell preprocessMethodCell = new PdfPCell(preprocessMethodTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),
							};
							mainTable3.AddCell(preprocessMethodCell);

							PdfPCell blankCell4 = new PdfPCell(new Phrase(" "))
							{
								Colspan = 3,
								FixedHeight = 15f, // Adjust height as needed
								Border = PdfPCell.NO_BORDER
							};

							mainTable3.AddCell(blankCell4);

							//Hold Flag
							PdfPTable preprocessHoldTable = new PdfPTable(1);
							preprocessHoldTable.AddCell(CreateLabelCell("Hold Flag : " + dt4.Rows[i]["hold_flag"], true));

							PdfPCell preprocessHoldCell = new PdfPCell(preprocessHoldTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),
							};
							mainTable3.AddCell(preprocessHoldCell);

							//Preprocess Order
							PdfPTable preprocessOrderTable = new PdfPTable(1);
							preprocessOrderTable.AddCell(CreateLabelCell("Preprocess Order : " + dt4.Rows[i]["preprocess_order"], true));

							PdfPCell preprocessOrderCell = new PdfPCell(preprocessOrderTable)
							{
								Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER,
								BackgroundColor = new BaseColor(230, 230, 250),
							};
							mainTable3.AddCell(preprocessOrderCell);

							// Add an empty blank space
							mainTable3.AddCell(new PdfPCell(new Phrase("")) { Border = PdfPCell.NO_BORDER });

							document.Add(mainTable3);
                            // Preprocess Filter

                            if (ds.Tables[1].Rows.Count > 0)
							{
								document.Add(CreateTitle("PreProcess Filter"));
								document.Add(PdfdynamicTableGenration(ds.Tables[1]));
								PdfPTable spacerTableAfter3 = new PdfPTable(1);
								PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
								{
									FixedHeight = 15f,
									Border = PdfPCell.NO_BORDER
								};
								spacerTableAfter3.AddCell(spacerCellAfter3);
								document.Add(spacerTableAfter3);
							}
							else
							{
								document.Add(CreateTitle("PreProcess Filter - No Records Found"));
							}

							// Query
							if (dt4.Rows[i]["process_method_code"].ToString() == "QCD_QUERY")
							{
                                if (ds.Tables[5].Rows.Count > 0)
                                {
                                    document.Add(CreateTitle("Query"));
                                    document.Add(PdfdynamicTableGenration(ds.Tables[5]));
                                    PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                    PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                    {
                                        FixedHeight = 15f,
                                        Border = PdfPCell.NO_BORDER
                                    };
                                    spacerTableAfter3.AddCell(spacerCellAfter3);
                                    document.Add(spacerTableAfter3);
                                }
                                else
                                {
                                    document.Add(CreateTitle("Query - No Records Found"));
                                }
                            }

                            // Lookup consition Header
                            else if (dt4.Rows[i]["process_method_code"].ToString() == "QCD_LOOKUP")
							{
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    document.Add(CreateTitle("Lookup Condition Header"));
                                    document.Add(PdfdynamicTableGenration(ds.Tables[3]));
                                    PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                    PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                    {
                                        FixedHeight = 15f,
                                        Border = PdfPCell.NO_BORDER
                                    };
                                    spacerTableAfter3.AddCell(spacerCellAfter3);
                                    document.Add(spacerTableAfter3);
                                }
                                else
                                {
                                    document.Add(CreateTitle("Lookup Condition Header - No Records Found"));
                                }



                                if (ds.Tables[4].Rows.Count > 0)
                                {
                                    document.Add(CreateTitle("Lookup Condition details"));
                                    document.Add(PdfdynamicTableGenration(ds.Tables[4]));
                                    PdfPTable spacerTableAfter3 = new PdfPTable(1);
                                    PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
                                    {
                                        FixedHeight = 15f,
                                        Border = PdfPCell.NO_BORDER
                                    };
                                    spacerTableAfter3.AddCell(spacerCellAfter3);
                                    document.Add(spacerTableAfter3);
                                }
                                else
                                {
                                    document.Add(CreateTitle("Lookup Condition details - No Records Found"));
                                }
                            }
							else if (dt4.Rows[i]["process_method_code"].ToString() == "QCD_FUNCTION")
							{
								if (ds.Tables[2].Rows.Count > 0)
								{
									document.Add(CreateTitle("Function"));
									document.Add(PdfdynamicTableGenration(ds.Tables[2]));
									PdfPTable spacerTableAfter3 = new PdfPTable(1);
									PdfPCell spacerCellAfter3 = new PdfPCell(new Phrase(" "))
									{
										FixedHeight = 15f,
										Border = PdfPCell.NO_BORDER
									};
									spacerTableAfter3.AddCell(spacerCellAfter3);
									document.Add(spacerTableAfter3);
								}
								else
								{
									document.Add(CreateTitle("Function - No Records Found"));
								}
							}
						}
					}
					/* Table Ends PreProcess */
					document.Close();
					byte[] pdfBytes = ms.ToArray();
				}
				return ms.ToArray();
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_report_reconversionhistory" + "Error Message:" + ex.Message);
				objlog.commonDataapi("", "SP", ex.Message, "pr_report_reconversionhistory", headerval.user_code, constring);
				return null;
			}
		}

	}
}
