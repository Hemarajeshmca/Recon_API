using ReconDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static ReconModels.RulesetupModel;

namespace ReconServiceLayer
{
    public class RulesetupService
    {
        //public getRulelist() {


        //}
        public static DataTable getRulelist(Rulesetuplist objrulesetuplist)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.Rulesetuplistdata(objrulesetuplist);
            }
            catch (Exception e)
            { }
            return ds; 
        }

        public static DataTable ruleheader(Rulesetupheader objrulesetupheader)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.Rulesetupheaderdata(objrulesetupheader);
            }
            catch (Exception e)
            { }
            return ds;
        }
        

        public static DataTable Rulegrouping(Rulegrouping objrulegrouping)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.RulegroupingData(objrulegrouping);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable Ruleidentifier(RuleIdentifier objruleidentifier)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.RuleidentifierData(objruleidentifier);
            }
            catch (Exception e)
            { }
            return ds;
        }
        

        public static DataTable Rulecondition(RuleCondition objrulecondition)
        {
            DataTable ds = new DataTable();
            try
            {
                RulesetupData objrule = new RulesetupData();
                ds = objrule.RuleconditionData(objrulecondition);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}
