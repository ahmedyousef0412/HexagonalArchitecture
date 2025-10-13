using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs;

public record UpdateOrderItemDto(int ItemId, string ProductName, int Quantity, decimal Price);

