import React from "react";
import { useState } from "react";
import { Link } from "react-router-dom";

const RegisterBox = () => {
  const [formData, setFormData] = useState({
    username: "",
    email: "",
    password: "",
  });
  const handleInputChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
    console.log(formData);
  };
  const handleRegister = async (e) => {
    e.preventDefault();
    const response = await fetch("http://localhost:5070/api/account/register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        username: e.target.username.value,
        email: e.target.email.value,
        password: e.target.password.value,
      }),
    });
    const data = await response.json();
    setFormData({
      username: "",
      email: "",
      password: "",
    });
    console.log(data);
  };
  return (
    <div className="flex justify-center items-center h-screen">
      <div className="bg-blue-200 w-1/3 my-auto rounded-xl p-6">
        <h1 className="text-3xl font-medium mb-6">Register a new account</h1>
        <form onSubmit={handleRegister}>
          <div className="p-3">
            <label className="text-xl" htmlFor="username">
              Username:{" "}
            </label>
            <input
              onChange={handleInputChange}
              value={formData.username}
              type="text"
              placeholder="Username"
              name="username"
            ></input>
          </div>
          <div className="p-3">
            <label className="text-xl" htmlFor="email">
              Email:{" "}
            </label>
            <input
              onChange={handleInputChange}
              value={formData.email}
              type="email"
              placeholder="Email"
              name="email"
            ></input>
          </div>
          <div className="p-3">
            <label className="text-xl" htmlFor="password">
              Password:{" "}
            </label>
            <input
              onChange={handleInputChange}
              value={formData.password}
              type="password"
              placeholder="Password"
              name="password"
            ></input>
          </div>
          <div className="p-4 flex items-center justify-between">
            <input
              className="text-xl px-8 py-4 hover:bg-slate-400"
              type="submit"
              value={"Register"}
            ></input>
            <Link to={"/auth"} className="px-6 py-4 hover:bg-slate-400">
              Already have an account?
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
};

const Auth = () => {
  return (
    <div>
      <RegisterBox />
    </div>
  );
};

export default Auth;
