<?php
 class MySqlConnect
 {
     private $host;
	 private $user;
	 private $pass;
	 private $database;
	 
	 public $AffectedRows;

     function __construct($Host,$User,$Pass,$Database) 
	        { $this->host = $Host;
		      $this->user = $User;
		      $this->pass = $Pass;
		      $this->database = $Database; }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
    private function OpenDatabase()
        {  $Connection = mysqli_connect($this->host,$this->user,$this->pass,$this->database) or die("Some error occurred during connection " . mysqli_error($Con));  
           $this->AffectedRows=0;
		   return $Connection;}
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
    function ExecuteQuery($query)
        {  $Connection=$this->OpenDatabase(); 
           $result=mysqli_query($Connection,$query);
	       $this->AffectedRows=mysqli_affected_rows($Connection);
		   
	       mysqli_close($Connection);
       	   return $result; }	 
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
    function ExecuteMultiQuery($query)
        {    $Connection=$this->OpenDatabase(); 
             $result=mysqli_multi_query($Connection,$query);
			 $this->AffectedRows=mysqli_affected_rows($Connection);
			 
	         mysqli_close($Connection);
       	     return $result; }		 

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
    function DataFilter($Data)
	   { $Connection=$this->OpenDatabase();
	     $Data=mysqli_real_escape_string($Connection, $Data);
         mysqli_close($Connection);
	     return $Data;}

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
}
?>