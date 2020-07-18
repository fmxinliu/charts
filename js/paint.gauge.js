var domGauge = document.getElementById('containerGauge');
var chartGauge = echarts.init(domGauge);

var gauge = {
	series: [{
		name: 'gauger',
		type: 'gauge',
		min: 0,
		max: 100,
		splitNumber: 10,
		radius: '70%',
		axisLine: {				// 坐标轴线
			lineStyle: {		// 属性lineStyle控制线条样式
				width: 10
			}
		},
		axisTick: {				// 坐标轴小标记
			length: 15,			// 属性length控制线长
			lineStyle: {		// 属性lineStyle控制线条样式
				color: 'auto'
			},
			splitNumber: 10
		},
		splitLine: {			// 分隔线
			length: 20,			// 属性length控制线长
			lineStyle: {		// 属性lineStyle（详见lineStyle）控制线条样式
				color: 'auto'
			}
		},
		detail: {
			formatter: "{value}%"
		},
		title: {
			show: false,
			fontSize: 20,
			fontStyle: 'normal',
			fontWeight: 'bolder',
			color: 'rgba(255, 0, 0, 1)',
			offsetCenter: ['0', '-160'],
		},
		data: [{value: 40, name: '%'}]
	}],
	title: {
		text: '日产量合格率',
		left: "center",
		top: "top",
		textStyle: {
			fontSize: 20,
			fontStyle: 'normal',
			fontWeight: 'bolder',
			color: 'rgba(255, 0, 0, 1)'
		},
		padding: 60
	}
};

chartGauge.setOption(gauge);
