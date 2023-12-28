namespace ConceptsPOO
{
    public abstract class Employee : IPay
    {
        public int Id { get; set; }
        public Date BirthDate { get; set; }
        public int Document { get; set; }
        public string FirstName { get; set; }
        public Date HiringDate { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public abstract decimal GetValueToPay();

        public override string ToString()
        {
            return $"{Id} -\n {FirstName} -\n {LastName} " +
                $"\n\t, BirthDate : {BirthDate:00} , Hiring : {HiringDate:00} " +
                $"\n\t, Active {IsActive}";
        }
    }
}
