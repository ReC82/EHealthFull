package com.example.demo;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ClinicController {
	
	@Autowired
	private clinicRepository clinicRepo;
	
	@GetMapping("/")
	public String index()
	{
	
		return "Welcome";
	}
	
	@PostMapping("/saveClinic")
	public Clinic saveData(@RequestBody Clinic clinic)
	{
		clinicRepo.save(clinic);
		return clinic;
	}
	//All the clinics
	@GetMapping("/getClinics")
	public List<Clinic> getAllClinics()
	{
		List<Clinic> clinicList = clinicRepo.findAll();
		return clinicList;
	}
	
	@DeleteMapping("/deleteClinic/{Id}")
	public String deleteClinic(@PathVariable int Id) {
		Clinic clinic = clinicRepo.findById(Id).get();
		if(clinic != null)
			clinicRepo.delete(clinic);
		return "Deleted !";
	}
	
	@PutMapping("/update")
	public Clinic updateClinic(@RequestBody Clinic clinic) {
		clinicRepo.save(clinic);
			return clinic;
	}
	
	//get clinic by id
	@GetMapping("/getClinic")
	public Clinic getClinic(@PathVariable int Id) {
		Optional<Clinic> clinic = clinicRepo.findById(Id);
		Clinic selectedClinic = clinic.get();
		return selectedClinic;
	}
	
}
