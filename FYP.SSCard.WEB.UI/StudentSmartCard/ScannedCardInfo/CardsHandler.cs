using StudentSmartCard;
using StudentSmartCard.ScannedCardInfo;
using StudentSmartCard.Student;
using StudentSmartCard.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSmartCard.UserManagement
{
    public class CardsHandler
    {
        public bool AddScnannedCardInformation(string cardId, int processedBy) // processedBy could be the admin or librarian or ....
        {
            try
            {
                SmartCardDB context = new SmartCardDB();
                context.ScannedCardInfo.Add(new ScannedCardInformation()
                {
                    CardId = cardId,
                    IsProcessed = false,
                    ProcessedBy = processedBy,
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool UpdateCardInformation(int Id)
        {
            try
            {
                SmartCardDB context = new SmartCardDB();
                ScannedCardInformation scannedCardInformation = context.ScannedCardInfo.FirstOrDefault(x => x.Id == Id);
                scannedCardInformation.IsProcessed = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public StudentCard GetStudentCardInfo(int studentId)
        {
            using (SmartCardDB context = new SmartCardDB())
            {
                return context.StudentCard.FirstOrDefault(x => x.StudentId == studentId);

            }
        }

        public ScannedCardInformation GetScannedCardInformation()
        {
            try
            {
                using (SmartCardDB context = new SmartCardDB())
                {
                    ScannedCardInformation scannedCardInformation = context.ScannedCardInfo.FirstOrDefault(x => x.IsProcessed == false);
                    return scannedCardInformation;
                }

            }
            catch (Exception ex)
            {

                return null;
            }

        }





    }
}
