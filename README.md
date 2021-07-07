

## About Project

This is a simple object mapper project which is written with C#.

The purpose of the project is to map large entity objects to smaller dto objects.

Solution consist of one console, one library and one test project. 

## Installation

Package can be installed via Package Manager Console with the following command:

`Install-Package MapperLibrary.ObjectMapper -Version 1.0.0`

## Usage

1. After installing the nuget package, import MapperLibrary to Startup.cs: 

```csharp
using MapperLibrary.Interfaces;
``` 

Then in the ConfigureServices method assign your Entities to DTOs with MapperContainer:

```csharp
MapperContainer.Assign<Address, AddressDTO>();
MapperContainer.Assign<Employee, EmployeeDTO>();
MapperContainer.Assign<Person, PersonDTO>();
``` 

Finally, IMapper interface and Mapper class should be injected to IServiceCollection in the ConfigureServices method:

```csharp
services.AddScoped<IMapper, Mapper>();
```

2. In the service or controller layer, IMapper can be created and assigned from constructor of related layer like the following:

```csharp
private readonly IMapper _mapper;

public WeatherForecastController(IMapper mapper)
{
     _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
}
```

Then, private _mapper object can map any object to a new instance of assigned type.

```csharp
Person person = new Person
{
    Id = Guid.NewGuid(),
    Name = "Test",
    Surname = "Test",
    BirthDate = DateTime.Now,
    IdentityNumber = 12345678901
};

object objectDto = _mapper.Map(person);
PersonDTO personDto = _mapper.Map<PersonDTO>(person);
```

If destination type is given to Map method, the mapper will return the new object with assigned destination type. In this example, destination type is PersonDTO. If destination type is not assigned, then mapper will return the new object with object type. 

## Contribution

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)

[Project License](https://github.com/yenicead/ObjectMapper/blob/main/LICENSE)