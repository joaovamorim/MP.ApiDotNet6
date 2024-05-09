using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }


        public Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date);
        }

        public Purchase(int id, int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(id < 0, "ID deve ser informado!");
            Id = id;
        }

        private void Validation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(productId < 0, "ID do Produto deve ser informado!");
            DomainValidationException.When(personId < 0, "ID Pessoa deve ser informado!");
            DomainValidationException.When(!date.HasValue, "Data da Compra deve ser informada!");

            PersonId = personId;
            ProductId = productId;
            Date = date.Value;
        }
    }
}