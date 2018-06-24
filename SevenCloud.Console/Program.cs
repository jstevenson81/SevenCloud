using NHapi.Model.V24.Message;

namespace SevenCloud.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = @"MSH|^~\&|EPIC|ANCL||IRIS|20170410102836|HJ123|ORM^O01|254|T|2.4||||||||
PID|1|ITCC20170410^^^^MRN|ITCC20170410||DOE^JOHN||19581012|M||W|100 FOAMY WAY^APT A^BELLEVUE^WA^98104^US^^^KING|KING|(425)444-5555^^PH^^^425^4445555|||M||1234|111-22-3333|||
PV1||O|POC01|||||||||||||||||||||||||||||||||||||||||20170410082742|||||
ORC|NW|2017041006^EPC|||||^^^20170410^^R||20170410150905|HJ123^HOPKINS^JOHNS||OP0001^DOE^JACK^^^^^^SERDOTON^^^^SERDOTON|DFM^^^20403^^^^^TEST CLINIC|(425)123-4567^^^^^425^1234567||||H48033^H48033^^20403001^TEST CLINIC|||||||||||O|||
OBR|1|2017041006^EPC||92250^FUNDUS PHOTOGRAPHY^EAP^^FUNDAL PHOTO||20170410|||||L|||||OP0001^DOE^JACK^^^^^^SERDOTON^^^^SERDOTON|(425)598-6900^^^^^425^5986900|||||||OPHTHALMOLOG|||^^^20170410^^R|||||||||20170410||||||||
DG1|1|ICD-10|E11.41^Type 2 diabetes mellitus with diabetic mononeuropathy^I10|Type 2 diabetes mellitus with diabetic mononeuropathy
DG1|2|ICD-9|250.0|DIABETES MELLITUS WITHOUT MENTION OF COMPLICATION, TYPE II OR UNSPECIFIED TYPE, NOT STATED AS UNCONTROLLED";
            var parser = new Parser.Parser();
            var parsedMessage = parser.Parse(message);
            var structure = parsedMessage.GetStructureName();
            System.Console.WriteLine($"Message Type: {parsedMessage.GetStructureName()}");
            if (structure == "ORM_O01")
            {
                var orm = parsedMessage as ORM_O01;
                System.Console.WriteLine(
                    $"Patient Id: {orm.PATIENT.PID.PatientID.ID}.  Patient Id Type: {orm.PATIENT.PID.PatientID.IdentifierTypeCode}");
                var patientName = orm.PATIENT.PID.GetPatientName();
                foreach (var name in patientName)
                {
                    System.Console.WriteLine($"Patient Last Name: {name.FamilyName.Surname}.  Patient First Name: {name.GivenName}");

                }
            }

        }
    }
}
