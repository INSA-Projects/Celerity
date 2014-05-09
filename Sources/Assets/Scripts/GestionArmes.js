function Awake() {
	SelectWeapon(0);
}

function Start () {

}

function Update()
{
  if (Input.GetKeyDown("1")||Input.GetKeyDown("c"))
 {
    SelectWeapon(0);
  }       
  else if (Input.GetKeyDown("2")||Input.GetKeyDown("v"))
 {
    SelectWeapon(1);
}
}


function SelectWeapon(index : int) 
{
  for (var i=0;i<transform.childCount;i++)
 {
    // Activate the selected weapon
    if (i == index) {
      transform.GetChild(i).gameObject.SetActive(true);
      }
    // Deactivate all other weapons
    else {
      transform.GetChild(i).gameObject.SetActive(false);
      }
 }
}