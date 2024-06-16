using Microsoft.AspNetCore.Mvc;
using Paz.APIs.Common;
using Paz.Infrastructure.Models;

namespace Paz.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class CustomerFindMany : FindManyInput<Customer, CustomerWhereInput> { }
