using RestaurantManagement.Models.Entity;
using RestaurantManagement.Models.Response;
using RestaurantManagement.DataService.Interface;
using RestaurantManagement.Data.Context;
using RestaurantManagement.Common.Constants;

namespace RestaurantManagement.DataService.Implementation
{
    public class AdminManagementDataServices : IAdminManagementDataService
    {
        private readonly RestaurentManagementContext restaurentmanagementcontext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminManagementDataServices"/> class.
        /// </summary>
        /// <param name="context">The database context for restaurant management.</param>
        public AdminManagementDataServices(RestaurentManagementContext context)
        {
            restaurentmanagementcontext = context;
        }

        /// <summary>
        /// Retrieves all pending orders for the admin.
        /// </summary>
        /// <returns>A list of pending order responses.</returns>
        public List<OrderResponse> SeeAllPendingOrder()
        {
            return restaurentmanagementcontext.Set<Orders>()
                .Where(order => order.OrderStatus == 1)
                .Select(order => new OrderResponse
                {
                    OrderId = order.OrderId,
                    UserId = order.UserId,
                    TableId = order.TableId,
                    Name = restaurentmanagementcontext.Set<Menus>()
                        .Where(menu => menu.MenuId == order.MenuId)
                        .Select(menu => menu.Name)
                        .FirstOrDefault() ?? "",
                    Quantity = order.Quantity,
                    Price = order.Price,
                    message = AdminConstants.PENDING_MESSAGE
                }).ToList();
        }

        /// <summary>
        /// Retrieves user details based on the employee ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>The user details if found, otherwise null.</returns>
        public Users? GetUserById(int employeeId)
        {
            return restaurentmanagementcontext.Set<Users>()
                .FirstOrDefault(employee => employee.Id == employeeId);
        }

        /// <summary>
        /// Checks if the provided attendance type ID is valid.
        /// </summary>
        /// <param name="attendanceTypeId">The ID of the attendance type.</param>
        /// <returns>True if the attendance type is valid, otherwise false.</returns>
        public bool IsAttendanceTypeValid(int attendanceTypeId)
        {
            return restaurentmanagementcontext.Set<AttendanceTypes>()
                .Any(attendance => attendance.Id == attendanceTypeId);
        }

        /// <summary>
        /// Saves the attendance record of an employee.
        /// </summary>
        /// <param name="attendanceRecord">The attendance record to be saved.</param>
        /// <returns>True if the attendance record is successfully saved, otherwise false.</returns>
        public bool SaveAttendance(EmployeAttendance attendanceRecord)
        {
            try
            {
                restaurentmanagementcontext.Set<EmployeAttendance>().Add(attendanceRecord);
                restaurentmanagementcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves order analysis data to determine the most sold items within a specific year and month.
        /// </summary>
        /// <param name="year">The year for analysis.</param>
        /// <param name="month">The month for analysis.</param>
        /// <returns>An object containing order analysis results.</returns>
        public OrderAnalysisResponse GetOrderAnalysisData(int year, int month)
        {
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = startDate.AddMonths(1);

            var orderedItems = restaurentmanagementcontext.Set<Orders>()
                .Where(order => order.OrderDateTime >= startDate && order.OrderDateTime < endDate)
                .GroupBy(order => order.Menus!.Name)
                .Select(orderGroup => new
                {
                    ItemName = orderGroup.Key!,
                    OrderCount = orderGroup.Sum(order => order.Quantity)
                })
                .OrderByDescending(item => item.OrderCount)
                .ToDictionary(item => item.ItemName!, item => item.OrderCount);

            return new OrderAnalysisResponse
            {
                OrderedItems = orderedItems,
                IsSuccess = orderedItems.Count > 0
            };
        }
    }
}