package com.example.demo;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;


@Entity

public class User {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	private String username;

	private String password;
	
	private String usertype;
	



	public User() {
		super();
		// TODO Auto-generated constructor stub
	}





	public User(int uid, String un, String pwd, String ut) {
		super();
		id = uid;
		username = un;
		password  = pwd;
		usertype = ut;
	}




	public int getId() {
		return id;
	}





	public String getUsertype() {
		return usertype;
	}





	public void setUsertype(String usertype) {
		this.usertype = usertype;
	}





	public void setId(int id) {
		this.id = id;
	}





	public String getUsername() {
		return username;
	}





	public void setUsername(String username) {
		this.username = username;
	}





	public String getPassword() {
		return password;
	}





	public void setPassword(String password) {
		this.password = password;
	}





	@Override
	public String toString() {
		return "User [id=" + id + ", username=" + username + ", password=" + password + ", usertype=" + usertype + "]";
	}





	


	


	


	

}
