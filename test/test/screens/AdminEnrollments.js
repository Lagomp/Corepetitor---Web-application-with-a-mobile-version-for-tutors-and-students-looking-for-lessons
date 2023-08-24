import React from "react";
import { View, Button, Text, StyleSheet } from "react-native";
import { useState } from "react";
import { ScrollView } from "react-native";
import { TouchableOpacity } from "react-native";

const Messages = () => {
  const [tableData, setTableData] = useState([
    {
      id: 1,
      StartDate: "Tutor tutorowski",
      EndDate: "Matematyka",
      Status: "Okej.",
    },
    {
      id: 2,
      StartDate: "Tutor tutorowski",
      EndDate: "Matematyka",
      Status: "Okej.",
    },
    {
      id: 3,
      StartDate: "Tutor tutorowski",
      EndDate: "Matematyka",
      Status: "Okej.",
    },
    {
      id: 4,
      StartDate: "Tutor tutorowski",
      EndDate: "Matematyka",
      Status: "Okej.",
    },
    {
      id: 5,
      StartDate: "Tutor tutorowski",
      EndDate: "Matematyka",
      Status: "Okej.",
    },
  ]);

  return (
    <ScrollView>
      <View style={styles.container}>
        <Text
          style={{
            textAlign: "center",
            fontSize: 30,
            paddingTop: 60,
            flex: 1,
            fontWeight: "600",
            color: "#A40303",
          }}
        >
          Wiadomości
        </Text>

        <View
          style={{
            marginTop: 30,
            marginLeft: 15,
            flex: 1,
            alignSelf: "stretch",
            borderWidth: 2,
            borderColor: "black",
            borderRadius: 15,
            padding: 10,
            marginRight: 8,
            backgroundColor: "white",

            //flexDirection: 'row',
          }}
        >
          <View style={styles.tableHeader}>
            <Text style={styles.headerText}>Imię</Text>
            <Text style={styles.headerText}>Przedmiot</Text>
            <Text style={styles.headerText}>Wiadomość</Text>
          </View>
          {tableData.map((item) => (
            <View key={item.id} style={styles.tableRow}>
              <Text style={styles.rowText}>{item.StartDate}</Text>
              <Text style={styles.rowText}>{item.EndDate}</Text>
              <Text style={styles.statusText}>{item.Status}</Text>
            </View>
          ))}
        </View>
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    backgroundColor: "#F8FCD4",
  },
  tableHeader: {
    flexDirection: "row",
    justifyContent: "space-between",
    borderBottomWidth: 1,
    borderColor: "#ccc",
    paddingBottom: 10,
    marginBottom: 10,
    overflow: "scroll",
  },
  headerText: {
    fontWeight: "bold",
    fontSize: 16,
    width: "33%",
  },
  tableRow: {
    flexDirection: "row",
    justifyContent: "space-between",
    borderBottomWidth: 1,
    borderColor: "#ccc",
    paddingBottom: 10,
    marginBottom: 10,
  },
  rowText: {
    fontSize: 16,
    width: "33%",
  },

  statusText: {
    width: "33%",
    fontSize: 16,
  },
});

export default Messages;
