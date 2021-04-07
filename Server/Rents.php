<?php

	include_once("mysql.php"); 
	include_once("configuration.php"); 

	$JsonData = file_get_contents('php://input');      
	$JsonData=json_decode($JsonData);

	$Config=new Configuration();
	$MySQL=json_decode(json_encode($Config->MySQL));

	$MyRentsProfile = new RentsProfile($MySQL->Host, $MySQL->User,$MySQL->Pass,$MySQL->Database);

	if($JsonData->Process=="UpdateRentsProfile") //SAVE
	{  
		$MyRentsProfile->UpdateRecord($JsonData); 
	}
	else if($JsonData->Process=="LoadCarsProfile") //SEARCH CAR
	{  
		$MyRentsProfile->LoadCarRecord($JsonData); 
	}
	else if($JsonData->Process=="LoadClientsProfile") //SEARCH CLIENT
	{  
		$MyRentsProfile->LoadClientsRecord($JsonData);  
	}
	else if($JsonData->Process=="RemoveRentsProfile") //UNUSED
	{  
		$MyRentsProfile->RemoveRecord($JsonData); 
	}
	else if ($JsonData->Process=="LoadTransactionList") //RENT LIST
	{
		$MyRentsProfile->LoadTransaction();
	}else if ($JsonData->Process=="LoadRentList")  //SEARCH LIST
	{
		$MyRentsProfile->LoadRentList($JsonData); 
	}

	class Rents{}
	class Record extends Rents{}

	class RentsProfile
	{
		private $OpenMysql;

		function __construct($Host,$User,$Pass,$Database) 
		{ 
			$this->OpenMysql=new MySqlConnect($Host,$User,$Pass,$Database);
		}

		function UpdateRecord($RentsRecord)
		{   
			$MyQuery = "INSERT INTO transactions Values('" . $RentsRecord->RentID . "','" . $RentsRecord->ClientID . "','";
			$MyQuery .= $RentsRecord->CarID . "','" . $RentsRecord->ClientName . "','" . $RentsRecord->CarModel . "','";
			$MyQuery .= $RentsRecord->CarBrand . "','" . $RentsRecord->CarRate . "','" . $RentsRecord->RentDate . "','";
			$MyQuery .= $RentsRecord->RentFee . "','" . $RentsRecord->InsuranceFee . "','" . $RentsRecord->TotalCost . "','";
			$MyQuery .= $RentsRecord->NoofDays . "','" . $RentsRecord->IsReturn . "') ";
			$MyQuery .= "ON DUPLICATE KEY UPDATE ClientID='" . $RentsRecord->ClientID . "', CarID='" . $RentsRecord->CarID . "', ";
			$MyQuery .= "ClientName='" . $RentsRecord->ClientName . "', CarModel='" . $RentsRecord->CarModel . "',";
			$MyQuery .= "CarBrand='" . $RentsRecord->CarBrand . "', CarRate='" . $RentsRecord->CarRate . "',";
			$MyQuery .= "RentDate='" . $RentsRecord->RentDate . "', RentFee='" . $RentsRecord->RentFee . "',";
			$MyQuery .= "InsuranceFee='" . $RentsRecord->InsuranceFee . "', TotalCost='" . $RentsRecord->TotalCost . "',";
			$MyQuery .= "NoofDays='" . $RentsRecord->NoofDays . "'," . "IsReturn='" . $RentsRecord->IsReturn . "';";
			$result =  $this->OpenMysql->ExecuteQuery($MyQuery);

			if ($result)
			{
				$Rents=new Rents();
				$Rents->Status="Rents Record was Succesfully Updated.";
				echo json_encode($Rents);
			}
		}

		function LoadCarRecord($CarsRecord)
		{ 
			$queryCar  = "SELECT  * FROM car WHERE CarID LIKE '" . $CarsRecord->CarID . "'";	
			$result =  $this->OpenMysql->ExecuteQuery($queryCar);

			$RentsCar=new Rents();
			$RentsCar->Status="Request is Successfully Processed";
			$RentsCar->Record=new Record();

			while($row=mysqli_fetch_array($result)){
				$RentsCar->Record->CarID=$row["CarID"];
				$RentsCar->Record->Rate=$row["Rate"];
				$RentsCar->Record->Brand=$row["Brand"];
				$RentsCar->Record->Model=$row["Model"];
				$RentsCar->Record->PlateNo=$row["PlateNo"];
				$RentsCar->Record->Type=$row["Type"];
				$RentsCar->Record->Seater=$row["Seater"];
			}
			echo json_encode($RentsCar);
		} 

		function LoadClientsRecord($ClientsRecord)
		{
			$queryClient  = "SELECT  * FROM clientprofile WHERE ClientID LIKE '" . $ClientsRecord->ClientID . "'";	
			$result =  $this->OpenMysql->ExecuteQuery($queryClient);

			$Rents=new Rents();
			$Rents->Status="Request is Successfully Processed";
			$Rents->Record=new Record();

			while($row=mysqli_fetch_array($result)){
				$Rents->Record->ClientID=$row["ClientID"];
				$Rents->Record->FirstName=$row["FirstName"];
				$Rents->Record->MiddleName=$row["MiddleName"];
				$Rents->Record->LastName=$row["LastName"];
				$Rents->Record->ContactNo=$row["ContactNo"];
				$Rents->Record->LicenseNo=$row["LicenseNo"];
				$Rents->Record->Age=$row["Age"];
				$Rents->Record->Birthdate=$row["Birthday"];
				$Rents->Record->Address=$row["Address"];
			}
			echo json_encode($Rents);
		}

		function LoadTransaction()
		{
			$queryClient  = "SELECT  * FROM transactions ORDER BY RentID;";	
			$result =  $this->OpenMysql->ExecuteQuery($queryClient);
			$Rents=new Rents();
			$Rents->Status="Request is Successfully Processed";
 			
 			$i=0;
			while($row=mysqli_fetch_array($result)){
				$Rents->Record[$i] = new Record(); 
				$Rents->Record[$i]->RentID=$row["RentID"];
				$Rents->Record[$i]->ClientName=$row["ClientName"];
				$Rents->Record[$i]->CarModel=$row["CarModel"];
				$Rents->Record[$i]->CarBrand=$row["CarBrand"];
				$Rents->Record[$i]->CarRate=$row["CarRate"];
				$Rents->Record[$i]->RentDate=$row["RentDate"];
				$Rents->Record[$i]->TotalCost=$row["TotalCost"];
				$Rents->Record[$i]->NoofDays=$row["NoofDays"];
				$Rents->Record[$i]->IsReturn=$row["IsReturn"];
				$i++;
			}
			echo json_encode($Rents);

		}
		
		function LoadRentList($RentsRecord)
		{
			$queryClient  = "SELECT  * FROM transactions WHERE RentID LIKE '" . $RentsRecord->RentID . "'";	
			$result =  $this->OpenMysql->ExecuteQuery($queryClient);

			$Rents=new Rents();
			$Rents->Status="Request is Successfully Processed";
			$Rents->Record=new Record();

			while($row=mysqli_fetch_array($result)){
				$Rents->Record->RentID=$row["RentID"];
				$Rents->Record->ClientID=$row["ClientID"];
				$Rents->Record->CarID=$row["CarID"];
				$Rents->Record->ClientName=$row["ClientName"];
				$Rents->Record->CarModel=$row["CarModel"];
				$Rents->Record->CarBrand=$row["CarBrand"];
				$Rents->Record->CarRate=$row["CarRate"];
				$Rents->Record->RentDate=$row["RentDate"];
				$Rents->Record->RentFee=$row["RentFee"];
				$Rents->Record->InsuranceFee=$row["InsuranceFee"];
				$Rents->Record->TotalCost=$row["TotalCost"];
				$Rents->Record->NoofDays=$row["NoofDays"];
				$Rents->Record->IsReturn=$row["IsReturn"];
			}
			echo json_encode($Rents);
		}

	}

?>