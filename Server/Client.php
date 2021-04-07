<?php

	include_once("mysql.php"); 
	include_once("configuration.php"); 

	$JsonData = file_get_contents('php://input');      
	$JsonData=json_decode($JsonData);

	$Config=new Configuration();
	$MySQL=json_decode(json_encode($Config->MySQL));

	$MyClientsProfile = new ClientsProfile($MySQL->Host, $MySQL->User,$MySQL->Pass,$MySQL->Database);

	if($JsonData->Process=="UpdateClientsProfile") //SAVE
	{ 
		$MyClientsProfile->UpdateRecord($JsonData); 
	}
	else if($JsonData->Process=="LoadClientsProfile") //SEARCH
	{  
		$MyClientsProfile->LoadRecord($JsonData);  
	}
	else if($JsonData->Process=="RemoveClientsProfile") 
	{ 
		$MyClientsProfile->RemoveRecord($JsonData); 
	}
	else if($JsonData->Process=="LoadClientsList") 
	{  
		$MyClientsProfile->ClientList(); 
	}
				  
	class Client{}
	class Record extends Client{}
	 
	class ClientsProfile
	{
		private $OpenMysql;

		function __construct($Host,$User,$Pass,$Database) 
		{ 
			$this->OpenMysql=new MySqlConnect($Host,$User,$Pass,$Database); 
		}

		function UpdateRecord($ClientsRecord)
		{   
			$MyQuery = "INSERT INTO clientprofile Values('" . $ClientsRecord->ClientID . "','" . $ClientsRecord->FirstName . "','";
			$MyQuery .= $ClientsRecord->MiddleName . "','" . $ClientsRecord->LastName . "','" . $ClientsRecord->ContactNo . "','";
			$MyQuery .= $ClientsRecord->LicenseNo . "','" . $ClientsRecord->Age . "','" . $ClientsRecord->Birthdate . "','";
			$MyQuery .= $ClientsRecord->Address . "') ";
			$MyQuery .= "ON DUPLICATE KEY UPDATE FirstName ='" . $ClientsRecord->FirstName . "', MiddleName='" . $ClientsRecord->MiddleName . "', ";
			$MyQuery .= "LastName='" . $ClientsRecord->LastName . "', ContactNo='" . $ClientsRecord->ContactNo . "',";
			$MyQuery .= "LicenseNo='" . $ClientsRecord->LicenseNo . "', Age='" . $ClientsRecord->Age . "',";
			$MyQuery .= "Birthday='" . $ClientsRecord->Birthdate . "'," . "Address='" . $ClientsRecord->Address . "';";

			$result =  $this->OpenMysql->ExecuteQuery($MyQuery);

			if ($result)
			{
				$Client=new Client();
				$Client->Status="Client Record was Succesfully Updated.";
				echo json_encode($Client);
			}
		}

		function LoadRecord($ClientsRecord)
		{ 
			$query  = "SELECT  * FROM clientprofile WHERE ClientID LIKE '" . $ClientsRecord->ClientID . "'";	
			$result =  $this->OpenMysql->ExecuteQuery($query);

			$Client=new Client();
			$Client->Status="Request is Successfully Processed";
			$Client->Record=new Record();

			while($row=mysqli_fetch_array($result)){
				$Client->Record->ClientID=$row["ClientID"];
				$Client->Record->FirstName=$row["FirstName"];
				$Client->Record->MiddleName=$row["MiddleName"];
				$Client->Record->LastName=$row["LastName"];
				$Client->Record->ContactNo=$row["ContactNo"];
				$Client->Record->LicenseNo=$row["LicenseNo"];
				$Client->Record->Age=$row["Age"];
				$Client->Record->Birthdate=$row["Birthday"];
				$Client->Record->Address=$row["Address"];
			}
			echo json_encode($Client);
		}

		function RemoveRecord($ClientsRecord)
		{       
			$query = "DELETE FROM clientprofile WHERE ClientID LIKE'" . $ClientsRecord->ClientID . "'";
			$result =  $this->OpenMysql->ExecuteQuery($query);
			$Num_rows =$this->OpenMysql->AffectedRows;
			$Client=new Client();
			$Client->Status="Request is Successfully Processed";
			$Client->Record=new Record();

			$Client->RecordCountDeleted=$Num_rows;
			echo json_encode($Client);
		}

		function ClientList()
		{       
			$query = "SELECT * FROM clientprofile ORDER BY ClientID;";
			$result =  $this->OpenMysql->ExecuteQuery($query);
			$Client=new Client();
			$Client->Status="Request is Successfully Processed";

			$i=0;
			while($row=mysqli_fetch_array($result)){
				$Client->Record[$i] = new Record(); 
				$Client->Record[$i]->ClientID=$row["ClientID"];
				$Client->Record[$i]->FirstName=$row["FirstName"];
				$Client->Record[$i]->MiddleName=$row["MiddleName"];
				$Client->Record[$i]->LastName=$row["LastName"];
				$Client->Record[$i]->ContactNo=$row["ContactNo"];
				$Client->Record[$i]->LicenseNo=$row["LicenseNo"];
				$Client->Record[$i]->Age=$row["Age"];
				$Client->Record[$i]->Birthdate=$row["Birthday"];
				$Client->Record[$i]->Address=$row["Address"];
				$i++;
			}
			echo json_encode($Client);
		}

	}

?>