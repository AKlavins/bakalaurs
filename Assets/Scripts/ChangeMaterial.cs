using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{

    public GameObject sphereObject;

    public Dropdown materialDropdown;

    public Material materialOne;

    public Material materialTwo;

    public Material materialThree;

    public GameObject textPlane;

    private string textOne = @"Ezernieku karsta kritenes ir 52 ha
plašs dabas piemineklis, kas 
atrodas Viduslatvijas zemienē 
Siguldas novadā Allažu pagastā. 
Kritenes ir karsta procesu rezultāts. 
Kopš 1977. gada šī vieta ir valsts 
aizsardzībā kā ģeoloģiskais dabas 
piemineklis, kopš 2001. gada 
iekļautas Latvijas aizsargājamo 
ģeoloģisko un ģeomorfoloģisko 
dabas pieminekļu sarakstā.";

    private string textTwo = @"Černausku akmens jeb Ezernieku 
akmens ir dižakmens, kas atrodas
Siguldas novada Allažu pagasta 
ziemeļu daļā, uz dienvidiem no 
valsts autoceļa V84.
Akmens parametri - garums — 
5,20 m, platums — 4,60 m, 
augstums — līdz 1,70 m. Akmens 
atrodas līdzenā vietā. Pirms 
Otrā Pasaules kara akmens atradies 
ganībās, tagad akmens ir mežā ar 
vāju pamežu";

    private string textThree = @"Mežmuižas avoti ir avotu 
sakopojums Rīgas rajona Allažu 
pagastā. Avoti iztek no Kaļķugravas 
nogāzes un atkarībā no nokrišņu 
daudzuma avotu skaits svārstās no 
3-14 avotiem. Šie avoti tek pa 
akmeņaino nogāzi un satek dzirnavu 
dīķī. Domājams, ka agrāk šeit 
atradusies Baltijas ledus ezera 
senkrasta nogāze";

    // Update is called once per frame
    void Update()
    {

        TextMesh t = (TextMesh)textPlane.GetComponent(typeof(TextMesh));
        
        switch(materialDropdown.value)
        {
            case 0:
                sphereObject.GetComponent<Renderer>().material = materialOne;
                t.text = textOne;
                break;
            case 1:
                sphereObject.GetComponent<Renderer>().material = materialTwo;
                t.text = textTwo;
                break;
            case 2:
                sphereObject.GetComponent<Renderer>().material = materialThree;
                t.text = textThree;
                break;
        }

    }
}
