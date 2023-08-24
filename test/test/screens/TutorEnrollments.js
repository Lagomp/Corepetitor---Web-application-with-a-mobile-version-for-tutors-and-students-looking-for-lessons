import React from "react";
import { View, Button, Text, StyleSheet } from "react-native";
import { useState } from "react";
import { ScrollView } from "react-native";
import { TouchableOpacity } from "react-native";

const StudentEnrollments = () => {
  const [tableData, setTableData] = useState([
    {
      id: 1,
      StartDate: "31.01.2023",
      EndDate: "04.02.2023",
      Status: "Zakończone",
    },
    {
      id: 2,
      StartDate: "06.02.2023",
      EndDate: "12.02.2023",
      Status: "Rozpoczęte",
    },
    {
      id: 3,
      StartDate: "07.02.2023",
      EndDate: "10.02.2023",
      Status: "Anulowane",
    },
    {
      id: 4,
      StartDate: "20.03.2023",
      EndDate: "17.05.2023",
      Status: "Zakończone",
    },
    {
      id: 5,
      StartDate: "24.02.2023",
      EndDate: "26.02.2023",
      Status: "Anulowane",
    },
    {
      id: 6,
      StartDate: "23.05.2023",
      EndDate: "03.06.2023",
      Status: "Zakończone",
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
          Zarezerwowane spotkania
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
            <Text style={styles.headerText}>Data rozpoczęcia</Text>
            <Text style={styles.headerText}>Data zakończenia</Text>
            <Text style={styles.headerText}>Status</Text>
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
    fontSize: 16,
    width: "33%",
  },
});

export default StudentEnrollments;
