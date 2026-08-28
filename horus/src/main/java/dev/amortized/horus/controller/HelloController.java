package dev.amortized.horus.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/hello")
public class HelloController {
    
    
    @GetMapping
    public String helloWithGreeting(@RequestParam(defaultValue = "hello") String greeting){

        return greeting + " world";
    }

    @GetMapping("/{name}")
    public String HelloUser(@PathVariable String name){
        return "Hello " + name;
    }







}
    
