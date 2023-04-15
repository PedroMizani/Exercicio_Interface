namespace ExerInterface.Entities
{
    internal class Contract
    {
        public int NumberContract { get; set; }
        public DateTime DateContract { get; set; }
        public double TotalValueContract { get; set; }
           
        public List<Installment> Installments { get; set; } = new List<Installment>();

        public Contract(int numberContract, DateTime dateContract, double totalValueContract)
        {
            NumberContract = numberContract;
            DateContract = dateContract;
            TotalValueContract = totalValueContract;
            Installments = new List<Installment>();
        }

        public void AddInstallment(Installment installment)
        {
            Installments.Add(installment);
        }

    }
}
