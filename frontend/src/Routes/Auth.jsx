import React from "react";
import { Link } from "react-router-dom";

const LoginBox = () => {
  const handleLogin = async (e) => {
    e.preventDefault();
    const response = await fetch("http://localhost:5070/api/account/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        username: e.target.username.value,
        password: e.target.password.value,
      }),
    });
    const data = await response.json();
    localStorage.setItem("userToken", data.token);
  };
  return (
    <div className="flex justify-center items-center h-screen">
      <div className="bg-blue-200 w-1/3 my-auto rounded-xl p-6">
        <h1 className="text-3xl font-medium mb-6">Login into your account</h1>
        <form onSubmit={handleLogin}>
          <div className="p-3">
            <label className="text-xl" htmlFor="username">
              Username:{" "}
            </label>
            <input type="text" placeholder="Username" name="username"></input>
          </div>
          <div className="p-3">
            <label className="text-xl" htmlFor="password">
              Password:{" "}
            </label>
            <input
              type="password"
              placeholder="Password"
              name="password"
            ></input>
          </div>
          <div className="p-4 flex items-center justify-between">
            <input
              className="text-xl px-8 py-4 hover:bg-slate-400"
              type="submit"
              value={"Log In"}
            ></input>
            <Link to={"/register"} className="px-6 py-4 hover:bg-slate-400">
              Create new Account
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
      <LoginBox />
    </div>
  );
};

export default Auth;
