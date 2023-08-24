import React, { useState } from "react";
import { View, Text, TextInput, Button, StyleSheet } from "react-native";
import { AsyncStorage } from "react-native";
import SyncStorage from "sync-storage";
import axios from "axios";

const LoginPage = ({ navigation }) => {
  //const [email, setEmail] = useState(this.state.email);
  //const [password, setPassword] = useState('');

  this.state = {
    email: "",
    password: "",
  };

  function Login() {
    let _email = SyncStorage.get("loginEmail");
    let _password = SyncStorage.get("loginPassword");

    if (
      _email == undefined ||
      _email == "" ||
      _password == undefined ||
      _password == ""
    ) {
      alert("Proszę podaj prawidłowy adres E-mail lub hasło.");
      return;
    }
    if (_password != "Abcd@1234") {
      alert("Proszę podaj prawidłowy adres E-mail lub hasło.");
      return;
    }
    if (_email == "tutor@admin.com") {
      navigation.navigate("TutorDashboard");
    } else if (_email == "student@admin.com") {
      navigation.navigate("StudentDashboard");
    } else if (_email == "admin@admin.com") {
      navigation.navigate("AdminDashboard");
    }
  }

  function onTextChangeT(key, txt) {
    SyncStorage.set(key, txt);
  }
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Corepetitor</Text>
      <Text style={styles.titleH}>Logowanie</Text>
      <TextInput
        style={styles.input}
        placeholder="Podaj adres E-mail."
        value={this.email}
        onChangeText={(txt) => onTextChangeT("loginEmail", txt)}
        keyboardType="email-address"
        autoCapitalize="none"
      />
      <TextInput
        style={styles.input}
        placeholder="Podaj hasło."
        value={this.password}
        onChangeText={(txt) => onTextChangeT("loginPassword", txt)}
        secureTextEntry
      />
      <Button onPress={Login} title="Zaloguj się" color="#A40303" />
      <Text
        style={{
          textAlign: "center",
          fontSize: 20,
          paddingTop: 10,
          flex: 1,
          fontWeight: "500",
          color: "#A40303",
        }}
      >
        Zarejestruj się jako uczeń. Zarejestruj się jako korepetytor.
      </Text>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: "center",
    justifyContent: "center",
    backgroundColor: "#F8FCD4",
    paddingHorizontal: 20,
  },
  title: {
    fontSize: 34,
    fontWeight: "bold",
    marginBottom: 20,
    fontWeight: "900",
    color: "#A40303",
  },
  titleH: {
    fontSize: 20,
    fontWeight: "bold",
    marginBottom: 20,
    fontWeight: "900",
    color: "#A40303",
  },
  input: {
    width: "100%",
    height: 50,
    backgroundColor: "#eee",
    borderRadius: 5,
    paddingHorizontal: 10,
    marginBottom: 20,
  },
  button: {
    width: "100%",
    height: 50,
    backgroundColor: "#007bff",
    borderRadius: 5,
    alignItems: "center",
    justifyContent: "center",
  },
  buttonText: {
    color: "#fff",
    fontSize: 18,
    fontWeight: "bold",
  },
});

export default LoginPage;

