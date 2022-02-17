using Microsoft.AspNetCore.Mvc.RazorPages;
using Beauty2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty2.Models
{
    public class ServicePaymentsPageModel : PageModel
    {
        public List<AssignedMethodData> AssignedCategoryDataList;
        public void PopulateAssignedMethodData(Beauty2Context context,
        Service service)
        {
            var allPayments = context.Payment;
            var servicePayments = new HashSet<int>(
            service.ServicePayments.Select(c => c.PaymentID)); //
            AssignedMethodDataList = new List<AssignedMethodData>();
            foreach (var cat in allPayments)
            {
                AssignedMethodDataList.Add(new AssignedMethodData
                {
                    PaymentID = cat.ID,
                    Name = cat.PaymentName,
                    Assigned = servicePayments.Contains(cat.ID)
                });
            }
        }
        public void UpdateServicePayments(Beauty2Context context,
        string[] selectedPayments, Service serviceToUpdate)
        {
            if (selectedCategories == null)
            {
                serviceToUpdate.ServicePayments = new List<ServicePayment>();
                return;
            }
            var selectedPaymentsHS = new HashSet<string>(selectedPayments);
            var bookCategories = new HashSet<int>
            (serviceToUpdate.ServicePayments.Select(c => c.Payment.ID));
            foreach (var cat in context.Payment)
            {
                if (selectedPaymentsHS.Contains(cat.ID.ToString()))
                {
                    if (!servicePayments.Contains(cat.ID))
                    {
                        serviceToUpdate.ServicePayments.Add(
                        new ServiceCategory
                        {
                            ServiceID = serviceToUpdate.ID,
                            PaymentID = cat.ID
                        });
                    }
                }
                else
                {
                    if (servicePayments.Contains(cat.ID))
                    {
                        ServicePayment courseToRemove
                        = serviceToUpdate
                        .ServicePayments
                        .SingleOrDefault(i => i.PaymentID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
