<?php

	include_once("mysql.php"); 
	include_once("configuration.php"); 

	$JsonData = file_get_contents('php://input');      
	$JsonData=json_decode($JsonData);

	$Config=new Configuration();
	$MySQL=json_decode(json_encode($Config->MySQL));

	$MyCarProfiles = new CarsProfile($MySQL->Host, $MySQL->User,$MySQL->Pass,$MySQL->Database);
		  
	if($JsonData->Process=="UpdateCarsProfile") //SAVE
	{  
		$MyCarProfiles->UpdateRecord($JsonData);
	}
	else if($JsonData->Process=="LoadCarsProfile") //SEARCH
	{  
		$MyCarProfiles->LoadRecord($JsonData);  
	}
	else if($JsonData->Process=="RemoveCarsProfile") 
	{
		$MyCarProfiles->RemoveRecord($JsonData); 
	}
	else if($JsonData->Process=="LoadCarList") 
	{
		$MyCarProfiles->CarList(); 
	}
				  
	class Car{}

	class Record extends Car{}

	 
	class CarsProfile
	{
		private $OpenMysql;

		function __construct($Host,$User,$Pass,$Database) 
		{
			$this->OpenMysql=new MySqlConnect($Host,$User,$Pass,$Database);
		}

		function UpdateRecord($CarsRecord)
		{   
			$MyQuery = "INSERT INTO car Values('" . $CarsRecord->CarID . "','" . $CarsRecord->Rate . "','";
			$MyQuery .= $CarsRecord->Brand . "','" . $CarsRecord->Model . "','" . $CarsRecord->PlateNo . "','";
			$MyQuery .= $CarsRecord->Type . "','" . $CarsRecord->Seater . "') ";
			$MyQuery .= "ON DUPLICATE KEY UPDATE Rate='" . $CarsRecord->Rate . "', Brand='" . $CarsRecord->Brand . "', ";
			$MyQuery .= "Model='" . $CarsRecord->Model . "', PlateNo='" . $CarsRecord->PlateNo . "',";
			$MyQuery .= "Type='" . $CarsRecord->Type . "'," . "Seater='" . $CarsRecord->Seater . "';";

			$result =  $this->OpenMysql->ExecuteQuery($MyQuery);

			if ($result) {
				$Car=new Car();
				$Car->Status="Client Record was Succesfully Updated.";
				echo json_encode($Car);
			}
		}

		function LoadRecord($CarsRecord)
		{   
			$query  = "SELECT  * FROM car WHERE CarID LIKE '" . $CarsRecord->CarID . "'";	
			$result =  $this->OpenMysql->ExecuteQuery($query);

			$Car=new Car();
			$Car->Status="Request is Successfully Processed";
			$Car->Record=new Record();

			while($row=mysqli_fetch_array($result)){
				 $Car->Record->CarID=$row["CarID"];
				 $Car->Record->Rate=$row["Rate"];
				 $Car->Record->Brand=$row["Brand"];
				 $Car->Record->Model=$row["Model"];
				 $Car->Record->PlateNo=$row["PlateNo"];
				 $Car->Record->Type=$row["Type"];
				 $Car->Record->Seater=$row["Seater"];
			}
			echo json_encode($Car);
		}

		function RemoveRecord($CarsRecord)
		{       
			$query = "DELETE FROM car WHERE CarID LIKE'" . $CarsRecord->CarID . "'";
			$result =  $this->OpenMysql->ExecuteQuery($query);
			$Num_rows =$this->OpenMysql->AffectedRows;
			$Car=new Car();
			$Car->Status="Request is Successfully Processed";
			$Car->Record=new Record();
			$Car->RecordCountDeleted=$Num_rows;
			echo json_encode($Car);
		}

		function CarList()
		{       
			$query = "SELECT * FROM car ORDER BY CarID;";
			$result =  $this->OpenMysql->ExecuteQuery($query);
			$Car=new Car();
			$Car->Status="Request is Successfully Processed";

		    $i=0;
		    while($row=mysqli_fetch_array($result))
		    {
			         $Car->Record[$i] = new Record(); 
				     $Car->Record[$i]->CarID=$row["CarID"];
		    		 $Car->Record[$i]->Rate=$row["Rate"];
		    		 $Car->Record[$i]->Brand=$row["Brand"];
		    		 $Car->Record[$i]->Model=$row["Model"];
		    		 $Car->Record[$i]->PlateNo=$row["PlateNo"];
		    		 $Car->Record[$i]->Type=$row["Type"];
		    		 $Car->Record[$i]->Seater=$row["Seater"];
					 $i++;
			}	
			echo json_encode($Car);
		}

	}
 
?>