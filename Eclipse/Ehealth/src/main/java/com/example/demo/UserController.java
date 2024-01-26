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
public class UserController {

	@Autowired
	private userRepository userRepo;
	
	@PostMapping("/saveUser")
	public User saveData(@RequestBody User user)
	{
		userRepo.save(user);
		return user;
	}
	
	@GetMapping("/getUsers")
	public List<User> getAllUsers()
	{
		List<User> userList = userRepo.findAll();
		return userList;
	}
	
	@DeleteMapping("/deleteUser/{Id}")
	public String deleteUser(@PathVariable int Id) {
		User user = userRepo.findById(Id).get();
		if(user != null)
			userRepo.delete(user);
		return "Deleted !";
	}
	
	@PutMapping("/updateUser")
	public User  updateUserData(@RequestBody User user) {
		userRepo.save(user);
			return user;
	}
	
	@GetMapping("/getUser")
	public User getUser(@PathVariable int Id) {
		Optional<User> user = userRepo.findById(Id);
		User selectedUser = user.get();
		return selectedUser;
	}
	
	
	
	
	
}

