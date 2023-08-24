import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";

import LoginScreen from "./screens/Login";
import HomeScreen from "./screens/Home";
import DetailsScreen from "./screens/Details";
import TableScreen from "./screens/Table";
import DashboardScreen from "./screens/Dashboard";
import IfelseScreen from "./screens/If-else";
import TutorDashboard from "./screens/TutorDashboard";
import TutorSubjects from "./screens/TutorSubjects";
import StudentDashboard from "./screens/StudentDashboard";
import TutorEnrollments from "./screens/TutorEnrollments";
import StudentEnrollments from "./screens/StudentEnrollments";

import AdminDashboard from "./screens/AdminDashboard";
import AdminEnrollments from "./screens/AdminEnrollments";
import AdminSubjects from "./screens/AdminSubjects";
import Logout from "./screens/Logout";
import AdminUsers from "./screens/AdminUsers";

const Stack = createNativeStackNavigator();

const MyStack = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen
          name="Login"
          component={LoginScreen}
          options={{ title: "Logowanie" }}
        />
        <Stack.Screen name="Home" component={HomeScreen} />
        <Stack.Screen name="Details" component={DetailsScreen} />
        <Stack.Screen name="Table" component={TableScreen} />
        <Stack.Screen name="Dashboard" component={DashboardScreen} />
        <Stack.Screen
          name="TutorDashboard"
          component={TutorDashboard}
          options={{ title: "Panel korepetytora" }}
        />
        <Stack.Screen
          name="TutorSubjects"
          component={TutorSubjects}
          options={{ title: "Moje oferty" }}
        />
        <Stack.Screen
          name="TutorEnrollments"
          component={TutorEnrollments}
          options={{ title: "Zarezerwowane spotkania" }}
        />
        <Stack.Screen
          name="StudentDashboard"
          component={StudentDashboard}
          options={{ title: "Panel ucznia" }}
        />
        <Stack.Screen
          name="StudentEnrollments"
          component={StudentEnrollments}
          options={{ title: "Edytuj profil" }}
        />

        <Stack.Screen
          name="AdminDashboard"
          component={AdminDashboard}
          options={{ title: "Panel administratora" }}
        />
        <Stack.Screen
          name="AdminEnrollments"
          component={AdminEnrollments}
          options={{ title: "Wiadomości" }}
        />
        <Stack.Screen
          name="AdminSubjects"
          component={AdminSubjects}
          options={{ title: "Przedmioty" }}
        />
        <Stack.Screen
          name="AdminUsers"
          component={AdminUsers}
          options={{ title: "Uczniowie" }}
        />
        <Stack.Screen
          name="Logout"
          component={Logout}
          options={{ title: "Wylogowywanie" }}
        />
        <Stack.Screen name="If-else" component={IfelseScreen} />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default MyStack;
