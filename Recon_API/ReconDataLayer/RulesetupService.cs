using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static ReconModels.ReconModel;
using static ReconModels.RulesetupModel;
using static ReconModels.theme_model;
using static ReconModels.UserManagementModel;

namespace ReconServiceLayer
{
    public class RulesetupService
    {
        public static DataTable getRulelist(Rulesetuplist objrulesetuplist, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.Rulesetuplistdata(objrulesetuplist, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds; 
        }

        public static DataTable ruleheader(Rulesetupheader objrulesetupheader, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
				RulesetupData objrule = new RulesetupData();
                ds = objrule.Rulesetupheaderdata(objrulesetupheader, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        

        public static DataTable Rulegrouping(Rulegrouping objrulegrouping, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.RulegroupingData(objrulegrouping, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
		public static DataTable rulefieldorder(Rulefieldorder objRulefieldorder, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objrule = new RulesetupData();
				ds = objrule.rulefieldorderData(objRulefieldorder, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable Ruleidentifier(RuleIdentifier objruleidentifier, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.RuleidentifierData(objruleidentifier, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        

        public static DataTable Rulecondition(RuleCondition objrulecondition, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.RuleconditionData(objrulecondition, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataSet Rulefetch(fetchRule objfetchrule, UserManagementModel.headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.fetchRuleData(objfetchrule, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

		public static DataTable getCondition(getCondition objcondition, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objrule = new RulesetupData();
				ds = objrule.getConditionData(objcondition, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable getdataagainsRecon(getdataagainsRecon objdatarecon, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objrule = new RulesetupData();
				ds = objrule.getdataagainsReconData(objdatarecon, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable getRecon(getdataagainsRecon objdatarecon, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objrule = new RulesetupData();
				ds = objrule.getReconData(objdatarecon, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//getruleagainstRecon
		public static DataSet getruleagainstRecon(getruleagainstRecon objRecon, UserManagementModel.headerValue headerval, string constring)
		{
			DataSet ds = new DataSet();
			try
			{
				RulesetupData objrule = new RulesetupData();
				ds = objrule.getruleagainstReconData(objRecon, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//cloneReconRuleService
		public static DataTable cloneReconRuleService(cloneReconRuleModel objcloneReconRule, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objrule = new RulesetupData();
				ds = objrule.cloneReconRuleData(objcloneReconRule, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//getAllRuleListService
		public static DataTable getAllRuleListService(UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objrule = new RulesetupData();
				ds = objrule.getAllRuleListData(headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable ruleaggfunsrv(ruleAggfunction objAggfunction, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objDS = new RulesetupData();
				ds = objDS.ruleaggfunData(objAggfunction, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable ruleaggconditionsrv(ruleAggcondition objAggcondition, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objDS = new RulesetupData();
				ds = objDS.ruleaggconditionData(objAggcondition, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable getConditioncriteriarulesrv(getConditionrule objcondition, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				RulesetupData objDS = new RulesetupData();
				ds = objDS.getConditioncriteriaruleData(objcondition, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}
