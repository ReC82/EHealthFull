package com.example.demo;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

@Entity
public class Clinic {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int clinicId;

	private String clinicName;

	private String clinicAddress;

	private String clinicAddressNumber;
	
    public Clinic(int clinicId, String clinicName, String clinicAddress, String clinicAddressNumber,
			String clinicPostalCode, String clinicCity, String clinicEmail, String clinicPhone, String clinicInami) {
		super();
		this.clinicId = clinicId;
		this.clinicName = clinicName;
		this.clinicAddress = clinicAddress;
		this.clinicAddressNumber = clinicAddressNumber;
		this.clinicPostalCode = clinicPostalCode;
		this.clinicCity = clinicCity;
		this.clinicEmail = clinicEmail;
		this.clinicPhone = clinicPhone;
		this.clinicInami = clinicInami;
	}

	private String clinicPostalCode;

    private String clinicCity;

    private String clinicEmail;

    private String clinicPhone;

    private String clinicInami;
	
	public Clinic() {
		super();
		// TODO Auto-generated constructor stub
	}
	

	
	public int getClinicId() {
		return clinicId;
	}



	public void setClinicId(int clinicId) {
		this.clinicId = clinicId;
	}



	public String getClinicName() {
		return clinicName;
	}



	public void setClinicName(String clinicName) {
		this.clinicName = clinicName;
	}



	public String getClinicAddress() {
		return clinicAddress;
	}



	public void setClinicAddress(String clinicAddress) {
		this.clinicAddress = clinicAddress;
	}



	public String getClinicAddressNumber() {
		return clinicAddressNumber;
	}



	public void setClinicAddressNumber(String clinicAddressNumber) {
		this.clinicAddressNumber = clinicAddressNumber;
	}



	public String getClinicPostalCode() {
		return clinicPostalCode;
	}



	public void setClinicPostalCode(String clinicPostalCode) {
		this.clinicPostalCode = clinicPostalCode;
	}



	public String getClinicCity() {
		return clinicCity;
	}



	public void setClinicCity(String clinicCity) {
		this.clinicCity = clinicCity;
	}



	public String getClinicEmail() {
		return clinicEmail;
	}



	public void setClinicEmail(String clinicEmail) {
		this.clinicEmail = clinicEmail;
	}



	public String getClinicPhone() {
		return clinicPhone;
	}



	public void setClinicPhone(String clinicPhone) {
		this.clinicPhone = clinicPhone;
	}



	public String getClinicInami() {
		return clinicInami;
	}



	public void setClinicInami(String clinicInami) {
		this.clinicInami = clinicInami;
	}



	@Override
	public String toString() {
		return "Clinic [clinicId=" + clinicId + ", Name=" + clinicName + ", Address=" + clinicAddress + "]";
	}
	
	
}
