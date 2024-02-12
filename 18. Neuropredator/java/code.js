import React from "react";
import {observer} from "mobx-react";
import Text from "~/common/components/fields/Text";

class Page extends React.Component {
	render() {
		const {page} = this.props;
		const {paramsArray} = page;

		const fields = paramsArray
			? paramsArray.map(fieldConfig => (
				<Text key={fieldConfig.id} config={fieldConfig}/>
			))
			: [];

		return <div className="page">{fields}</div>;
	}
}

export default observer(Page);
