## Behavioral patterns / Strategy pattern

The intent of this pattern is to define a default behavior for an object class, so that manual null checks are not needed.

### Structure
The null object is commonly defined as a default implementation of an interface or a base class.

The example below uses real classes in example folders:

```
public class Usage
{
    private readonly IUsersRepository _usersRepository = new UsersRepository();
    private readonly TaxService _taxService = new TaxService();
    
    public void Use()
    {
        string personId = "001";
        IPerson person = GetPerson(personId);

        // regular approach on the client side, to avoid null reference exception on person.GetName()
        // if (person is null)
        // {
        //     throw new InvalidOperationException();
        // }
        // above is not needed, since the GetPerson returns default object instead of null

        var isOfAge = person.IsOfAge();

        var taxCalculator = _taxService.GetTaxCalculator();
        // regular approach with a manual null check
        // decimal taxAmount = 0;
        // if (taxCalculator is not null)
        // {
        //     taxAmount = taxCalculator.GetTaxValue(1000, 500);
        // }
        // as above, the null check is not needed
        var taxAmount = taxCalculator.GetTaxValue(1000, 500);
    }

    private IPerson GetPerson(string id)
    {
        var (name, _, age) = _usersRepository.GetPersonData(id);
        if (name is null)
        {
            return new NoPerson();
        }

        return new User(name, age);
    }
}

public class TaxService
{
    private readonly ITaxRateRepository _taxRateRepository;
    
    public TaxCalculator GetTaxCalculator()
    {
        var rate = _taxRateRepository.GetRateCodeSomehowLogically();
        return rate switch
        {
            "12" => new Pl12PercentTax(),
            "19" => new Pl19PercentTax(),
            _ => TaxCalculator.Default
        };
    }
}

internal interface ITaxRateRepository
{
    string GetRateCodeSomehowLogically();
}

internal interface IUsersRepository
{
    (string?, string?, int) GetPersonData(string id);
}

class UsersRepository : IUsersRepository
{
    public (string?, string?, int) GetPersonData(string id)
    {
        return id switch
        {
            "001" => ("John", "Doe", 29),
            "002" => ("Mary", "Sue", 15),
            _ => (null, null, 0)
        };
    }
}
```

### Related code
The Bridge pattern example also demonstrates a real world example with `NoDiscount`, `NoSpecialOffer`, `NoCoupon` classes, providing default behaviors instead of forcing the client to check for nulls.
