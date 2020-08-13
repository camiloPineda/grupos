<?php
error_reporting(E_ALL);
include('connection.php');

$request = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>
<KIU_AirAvailRQ EchoToken=\"$EchoToken\" TimeStamp=\"$TimeStamp\" Target=\"$_GET[partition]\" Version=\"3.0\" SequenceNmbr=\"$SequenceNmbr\" PrimaryLangID=\"en-us\" DirectFlightsOnly=\"$_GET[direct]\" MaxResponses=\"$_GET[maxresponses]\" CombinedItineraries=\"$_GET[combined]\">
	<POS>
		<Source AgentSine=\"$_GET[sine]\" TerminalID=\"$_GET[device]\">
		</Source>
	</POS>
	<SpecificFlightInfo>
		<Airline Code=\"$_GET[carrier]\"/>
	</SpecificFlightInfo>
	<OriginDestinationInformation>
		<DepartureDateTime>$_GET[date]</DepartureDateTime>
		<OriginLocation LocationCode=\"$_GET[source]\"/>
		<DestinationLocation LocationCode=\"$_GET[dest]\"/>
	</OriginDestinationInformation>
	<TravelPreferences>
		<CabinPref Cabin=\"$_GET[cabin]\"/>
	</TravelPreferences>
	<TravelerInfoSummary>
		<AirTravelerAvail>
			<PassengerTypeQuantity Code=\"ADT\" Quantity=\"1\"/>
		</AirTravelerAvail>
	</TravelerInfoSummary>
</KIU_AirAvailRQ>";

$conn = new connectionServer($_GET["user"], $_GET["pass"]);
$response = $conn->SendMessage($request);
$xml = simplexml_load_string($response);

if ($xml->Error->ErrorCode) {
	echo 'Error ' . $xml->Error->ErrorCode . ' "' . $xml->Error->ErrorMsg . '"';
} else {
	foreach ($xml->OriginDestinationInformation as $odi) {
		echo "<h3>" . $odi->DepartureDateTime . ": " . $odi->OriginLocation . "->" . $odi->DestinationLocation . "</h3>";
		$option_number = 1;
		foreach ($odi->OriginDestinationOptions->OriginDestinationOption as $odo) {
			$option = true;
			$fn = 1;
			$option_params = "{'SegmentsCount':" . count($odo->FlightSegment) . ", 'Segments':Array(";
			$option_string = "<hr/><h4>Option $option_number</h4>";
			$option_string .= '<table><tr><td>Source</td><td>Dest</td><td>Carrier</td><td>Flight</td><td>Departure</td><td>Arrival</td><td>Duration</td><td>Stops</td><td>Equi</td><td>Meal</td></tr>';
			foreach ($odo->FlightSegment as $fs) {
				$dairport = $fs->DepartureAirport['LocationCode'];
				$aairport = $fs->ArrivalAirport['LocationCode'];
				$flight = $fs['FlightNumber'];
				$time =  $fs['JourneyDuration'];
				$ddatetime = $fs['DepartureDateTime'];
				$adatetime = $fs['ArrivalDateTime'];
				$stops = $fs['StopQuantity'];
				$equipment = $fs->Equipment['AirEquipType'];
				$airline = $fs->MarketingAirline['CompanyShortName'];
				$meal = $fs->Meal['MealCode'];
				
				$available_classes = array();
				foreach ($fs->BookingClassAvail as $bca) {
					if (($bca['ResBookDesigQuantity'] >= '1') && ($bca['ResBookDesigQuantity'] <= '9')) {
						$available_classes[] = $bca['ResBookDesigCode'];
					}
				}
				if ($available_classes == array()) {
					$option = false;
					break;
				}
				
				$class_list = "Array('" . implode("', '", $available_classes) . "')";
				$option_params .= "{MarketingAirline:'$airline', FlightNumber:$flight, DepartureDateTime:'$ddatetime', ArrivalDateTime:'$adatetime', ";
				$option_params .= "DepartureAirport:'$dairport', ArrivalAirport:'$aairport', ResBookDesigCode:'$available_classes[0]', Classes:$class_list},";
				$option_string .= "<tr><td>$dairport</td><td>$aairport</td><td>$airline</td><td>$flight</td><td>$ddatetime</td><td>$adatetime</td><td>$time</td><td>$stops</td><td>$equipment</td><td>$meal</td></tr>";
				$fn++;
			}
			$option_params = substr($option_params,0,-1) . ")}";
			if ($option) echo "$option_string<tr><td colspan=\"10\"><input type=\"button\" value=\"Add\" onclick=\"add_segment($option_params)\"/></td></tr>";
			echo '</table>';
			if ($option) $option_number++;
		}
	}
}
function respuesta(){
	return $response;
}	

?>
