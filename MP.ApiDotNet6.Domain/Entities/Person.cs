
using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }


        public Person(string document, string name, string phone)
        {
            Validation(document, name, phone);   
        }

        public Person(int id, string document, string name, string phone)
        {
            DomainValidationException.When(id < 0, "ID deve ser maior que zero!");
            Id = id;
            Validation(document, name, phone);
        }
        
        private void Validation(string document, string name, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Telefone deve ser ifnormado!");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}