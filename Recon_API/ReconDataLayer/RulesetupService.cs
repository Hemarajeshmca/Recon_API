using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static ReconModels.ReconModel;
using static ReconModels.RulesetupModel;
using static ReconModels.UserManagementModel;

namespace ReconServiceLayer
{
    public class RulesetupService
    {
        //public getRulelist() {


        //}
        public static DataTable getRulelist(Rulesetuplist objrulesetuplist, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.Rulesetuplistdata(objrulesetuplist, headerval);
            }
            catch (Exception e)
            { }
            return ds; 
        }

        public static DataTable ruleheader(Rulesetupheader objrulesetupheader, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
				RulesetupData objrule = new RulesetupData();
                ds = objrule.Rulesetupheaderdata(objrulesetupheader, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }
        

        public static DataTable Rulegrouping(Rulegrouping objrulegrouping, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.RulegroupingData(objrulegrouping, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable Ruleidentifier(RuleIdentifier objruleidentifier, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.RuleidentifierData(objruleidentifier, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }
        

        public static DataTable Rulecondition(RuleCondition objrulecondition, UserManagementModel.headerValue headerval)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.RuleconditionData(objrulecondition, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataSet Rulefetch(fetchRule objfetchrule, UserManagementModel.headerValue headerval)
        {
            DataSet ds = new DataSet();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.fetchRuleData(objfetchrule, headerval);
            }
            catch (Exception e)
            { }
            return ds;
        }

		public static DataTable getCondition(getCondition objcondition, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objrule = new RulesetupData();
				ds = objrule.getConditionData(objcondition, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable getdataagainsRecon(getdataagainsRecon objdatarecon, UserManagementModel.headerValue headerval)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objrule = new RulesetupData();
				ds = objrule.getdataagainsReconData(objdatarecon, headerval);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}
