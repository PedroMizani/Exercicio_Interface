using System;
using ExerInterface.Entities;

namespace ExerInterface.Services
{
    internal class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            //Total value = 600, months = 3, logo basicQuota = 200
            double basicQuota = contract.TotalValueContract / months;

            for (int i = 1; i <= months; i++)
            {
                //adiciona 1 mes na data do contrato
                DateTime date = contract.DateContract.AddMonths(i);
                

                double updatedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _onlinePaymentService.PaymentFee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
