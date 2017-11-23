using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmrcDotNet.Model.TaxCalc.Response
{
    public class TaxCalculationResponse
    {
        public TaxCalculationResponse()
        {
            eoyEstimate = new Eoyestimate();
        }
        public float incomeTaxYTD { get; set; }
        public float incomeTaxThisPeriod { get; set; }
        public float payFromAllEmployments { get; set; }
        public float benefitsAndExpensesReceived { get; set; }
        public float allowableExpenses { get; set; }
        public float payFromAllEmploymentsAfterExpenses { get; set; }
        public float shareSchemes { get; set; }
        public float profitFromSelfEmployment { get; set; }
        public float profitFromPartnerships { get; set; }
        public float profitFromUkLandAndProperty { get; set; }
        public float dividendsFromForeignCompanies { get; set; }
        public float foreignIncome { get; set; }
        public float trustsAndEstates { get; set; }
        public float interestReceivedFromUkBanksAndBuildingSocieties { get; set; }
        public float dividendsFromUkCompanies { get; set; }
        public float ukPensionsAndStateBenefits { get; set; }
        public float gainsOnLifeInsurance { get; set; }
        public float otherIncome { get; set; }
        public float totalIncomeReceived { get; set; }
        public float paymentsIntoARetirementAnnuity { get; set; }
        public float foreignTaxOnEstates { get; set; }
        public float incomeTaxRelief { get; set; }
        public float incomeTaxReliefReducedToMaximumAllowable { get; set; }
        public float annuities { get; set; }
        public float giftOfInvestmentsAndPropertyToCharity { get; set; }
        public int personalAllowance { get; set; }
        public float marriageAllowanceTransfer { get; set; }
        public float blindPersonAllowance { get; set; }
        public float blindPersonSurplusAllowanceFromSpouse { get; set; }
        public float incomeExcluded { get; set; }
        public float totalIncomeAllowancesUsed { get; set; }
        public float totalIncomeOnWhichTaxIsDue { get; set; }
        public float payPensionsExtender { get; set; }
        public float giftExtender { get; set; }
        public float extendedBR { get; set; }
        public float payPensionsProfitAtBRT { get; set; }
        public float incomeTaxOnPayPensionsProfitAtBRT { get; set; }
        public float payPensionsProfitAtHRT { get; set; }
        public float incomeTaxOnPayPensionsProfitAtHRT { get; set; }
        public float payPensionsProfitAtART { get; set; }
        public float incomeTaxOnPayPensionsProfitAtART { get; set; }
        public float netPropertyFinanceCosts { get; set; }
        public float interestReceivedAtStartingRate { get; set; }
        public float incomeTaxOnInterestReceivedAtStartingRate { get; set; }
        public float interestReceivedAtZeroRate { get; set; }
        public float incomeTaxOnInterestReceivedAtZeroRate { get; set; }
        public float interestReceivedAtBRT { get; set; }
        public float incomeTaxOnInterestReceivedAtBRT { get; set; }
        public float interestReceivedAtHRT { get; set; }
        public float incomeTaxOnInterestReceivedAtHRT { get; set; }
        public float interestReceivedAtART { get; set; }
        public float incomeTaxOnInterestReceivedAtART { get; set; }
        public float dividendsAtZeroRate { get; set; }
        public float incomeTaxOnDividendsAtZeroRate { get; set; }
        public float dividendsAtBRT { get; set; }
        public float incomeTaxOnDividendsAtBRT { get; set; }
        public float dividendsAtHRT { get; set; }
        public float incomeTaxOnDividendsAtHRT { get; set; }
        public float dividendsAtART { get; set; }
        public float incomeTaxOnDividendsAtART { get; set; }
        public float totalIncomeOnWhichTaxHasBeenCharged { get; set; }
        public float taxOnOtherIncome { get; set; }
        public float incomeTaxDue { get; set; }
        public float incomeTaxCharged { get; set; }
        public float deficiencyRelief { get; set; }
        public float topSlicingRelief { get; set; }
        public float ventureCapitalTrustRelief { get; set; }
        public float enterpriseInvestmentSchemeRelief { get; set; }
        public float seedEnterpriseInvestmentSchemeRelief { get; set; }
        public float communityInvestmentTaxRelief { get; set; }
        public float socialInvestmentTaxRelief { get; set; }
        public float maintenanceAndAlimonyPaid { get; set; }
        public float marriedCouplesAllowance { get; set; }
        public float marriedCouplesAllowanceRelief { get; set; }
        public float surplusMarriedCouplesAllowance { get; set; }
        public float surplusMarriedCouplesAllowanceRelief { get; set; }
        public float notionalTaxFromLifePolicies { get; set; }
        public float notionalTaxFromDividendsAndOtherIncome { get; set; }
        public float foreignTaxCreditRelief { get; set; }
        public float incomeTaxDueAfterAllowancesAndReliefs { get; set; }
        public float giftAidPaymentsAmount { get; set; }
        public float giftAidTaxDue { get; set; }
        public float capitalGainsTaxDue { get; set; }
        public float remittanceForNonDomiciles { get; set; }
        public float highIncomeChildBenefitCharge { get; set; }
        public float totalGiftAidTaxReduced { get; set; }
        public float incomeTaxDueAfterGiftAidReduction { get; set; }
        public float annuityAmount { get; set; }
        public float taxDueOnAnnuity { get; set; }
        public float taxCreditsOnDividendsFromUkCompanies { get; set; }
        public float incomeTaxDueAfterDividendTaxCredits { get; set; }
        public float nationalInsuranceContributionAmount { get; set; }
        public float nationalInsuranceContributionCharge { get; set; }
        public float nationalInsuranceContributionSupAmount { get; set; }
        public float nationalInsuranceContributionSupCharge { get; set; }
        public float totalClass4Charge { get; set; }
        public float nationalInsuranceClass1Amount { get; set; }
        public float nationalInsuranceClass2Amount { get; set; }
        public float nicTotal { get; set; }
        public float underpaidTaxForPreviousYears { get; set; }
        public float studentLoanRepayments { get; set; }
        public float pensionChargesGross { get; set; }
        public float pensionChargesTaxPaid { get; set; }
        public float totalPensionSavingCharges { get; set; }
        public float pensionLumpSumAmount { get; set; }
        public float pensionLumpSumRate { get; set; }
        public float statePensionLumpSumAmount { get; set; }
        public float remittanceBasisChargeForNonDomiciles { get; set; }
        public float additionalTaxDueOnPensions { get; set; }
        public float additionalTaxReliefDueOnPensions { get; set; }
        public float incomeTaxDueAfterPensionDeductions { get; set; }
        public float employmentsPensionsAndBenefits { get; set; }
        public float outstandingDebtCollectedThroughPaye { get; set; }
        public float payeTaxBalance { get; set; }
        public float cisAndTradingIncome { get; set; }
        public float partnerships { get; set; }
        public float ukLandAndPropertyTaxPaid { get; set; }
        public float foreignIncomeTaxPaid { get; set; }
        public float trustAndEstatesTaxPaid { get; set; }
        public float overseasIncomeTaxPaid { get; set; }
        public float interestReceivedTaxPaid { get; set; }
        public float voidISAs { get; set; }
        public float otherIncomeTaxPaid { get; set; }
        public float underpaidTaxForPriorYear { get; set; }
        public float totalTaxDeducted { get; set; }
        public float incomeTaxOverpaid { get; set; }
        public float incomeTaxDueAfterDeductions { get; set; }
        public float propertyFinanceTaxDeduction { get; set; }
        public float taxableCapitalGains { get; set; }
        public float capitalGainAtEntrepreneurRate { get; set; }
        public float incomeTaxOnCapitalGainAtEntrepreneurRate { get; set; }
        public float capitalGrainsAtLowerRate { get; set; }
        public float incomeTaxOnCapitalGainAtLowerRate { get; set; }
        public float capitalGainAtHigherRate { get; set; }
        public float incomeTaxOnCapitalGainAtHigherTax { get; set; }
        public float capitalGainsTaxAdjustment { get; set; }
        public float foreignTaxCreditReliefOnCapitalGains { get; set; }
        public float liabilityFromOffShoreTrusts { get; set; }
        public float taxOnGainsAlreadyCharged { get; set; }
        public float totalCapitalGainsTax { get; set; }
        public float incomeAndCapitalGainsTaxDue { get; set; }
        public float taxRefundedInYear { get; set; }
        public float unpaidTaxCalculatedForEarlierYears { get; set; }
        public float marriageAllowanceTransferAmount { get; set; }
        public float marriageAllowanceTransferRelief { get; set; }
        public float marriageAllowanceTransferMaximumAllowable { get; set; }
        public string nationalRegime { get; set; }
        public int allowance { get; set; }
        public int limitBRT { get; set; }
        public int limitHRT { get; set; }
        public float rateBRT { get; set; }
        public float rateHRT { get; set; }
        public float rateART { get; set; }
        public int limitAIA { get; set; }
        public int allowanceBRT { get; set; }
        public int interestAllowanceHRT { get; set; }
        public int interestAllowanceBRT { get; set; }
        public int dividendAllowance { get; set; }
        public float dividendBRT { get; set; }
        public float dividendHRT { get; set; }
        public float dividendART { get; set; }
        public int class2NICsLimit { get; set; }
        public float class2NICsPerWeek { get; set; }
        public int class4NICsLimitBR { get; set; }
        public int class4NICsLimitHR { get; set; }
        public float class4NICsBRT { get; set; }
        public float class4NICsHRT { get; set; }
        public int proportionAllowance { get; set; }
        public int proportionLimitBRT { get; set; }
        public int proportionLimitHRT { get; set; }
        public float proportionalTaxDue { get; set; }
        public int proportionInterestAllowanceBRT { get; set; }
        public int proportionInterestAllowanceHRT { get; set; }
        public int proportionDividendAllowance { get; set; }
        public int proportionPayPensionsProfitAtART { get; set; }
        public int proportionIncomeTaxOnPayPensionsProfitAtART { get; set; }
        public int proportionPayPensionsProfitAtBRT { get; set; }
        public int proportionIncomeTaxOnPayPensionsProfitAtBRT { get; set; }
        public int proportionPayPensionsProfitAtHRT { get; set; }
        public int proportionIncomeTaxOnPayPensionsProfitAtHRT { get; set; }
        public int proportionInterestReceivedAtZeroRate { get; set; }
        public int proportionIncomeTaxOnInterestReceivedAtZeroRate { get; set; }
        public int proportionInterestReceivedAtBRT { get; set; }
        public int proportionIncomeTaxOnInterestReceivedAtBRT { get; set; }
        public int proportionInterestReceivedAtHRT { get; set; }
        public int proportionIncomeTaxOnInterestReceivedAtHRT { get; set; }
        public int proportionInterestReceivedAtART { get; set; }
        public int proportionIncomeTaxOnInterestReceivedAtART { get; set; }
        public int proportionDividendsAtZeroRate { get; set; }
        public int proportionIncomeTaxOnDividendsAtZeroRate { get; set; }
        public int proportionDividendsAtBRT { get; set; }
        public int proportionIncomeTaxOnDividendsAtBRT { get; set; }
        public int proportionDividendsAtHRT { get; set; }
        public int proportionIncomeTaxOnDividendsAtHRT { get; set; }
        public int proportionDividendsAtART { get; set; }
        public int proportionIncomeTaxOnDividendsAtART { get; set; }
        public int proportionClass2NICsLimit { get; set; }
        public int proportionClass4NICsLimitBR { get; set; }
        public int proportionClass4NICsLimitHR { get; set; }
        public int proportionReducedAllowanceLimit { get; set; }
        public Eoyestimate eoyEstimate { get; set; }
    }

    public class Eoyestimate
    {
        public Eoyestimate()
        {
            selfEmployment = new List<Selfemployment>();
            ukProperty = new List<Ukproperty>();
        }

        public List<Selfemployment> selfEmployment { get; set; }
        public List<Ukproperty> ukProperty { get; set; }
        public float totalTaxableIncome { get; set; }
        public float incomeTaxAmount { get; set; }
        public float nic2 { get; set; }
        public float nic4 { get; set; }
        public float totalNicAmount { get; set; }
        public float incomeTaxNicAmount { get; set; }
    }

    public class Selfemployment
    {
        public string id { get; set; }
        public float taxableIncome { get; set; }
        public bool supplied { get; set; }
        public bool finalised { get; set; }
    }

    public class Ukproperty
    {
        public float taxableIncome { get; set; }
        public bool supplied { get; set; }
        public bool finalised { get; set; }
    }


}
